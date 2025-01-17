﻿using DeliveryServiceApp.Models;
using DeliveryServiceApp.Services.Interfaces;
using DeliveryServiceData.UnitOfWork;
using DeliveryServiceData.UnitOfWork.Implementation;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace DeliveryServiceApp.Controllers
{
    public class ShipmentController : Controller
    {
        private readonly UserManager<Person> userManager;
        private readonly IServiceAdditonalService serviceAdditonalService;
        private readonly IServiceShipmentWeight serviceShipmentWeight;
        private readonly IServiceShipment serviceShipment;
        private readonly IServiceAddionalServiceShipment serviceAddionalServiceShipment;
        private readonly IServiceStatus serviceStatus;
        private readonly IServiceStatusShipment serviceStatusShipment;

        public ShipmentController(UserManager<Person> userManager, IServiceAdditonalService serviceAdditonalService, IServiceShipmentWeight serviceShipmentWeight,
                                  IServiceShipment serviceShipment, IServiceAddionalServiceShipment serviceAddionalServiceShipment, IServiceStatus serviceStatus,
                                  IServiceStatusShipment serviceStatusShipment)
        {
            this.userManager = userManager;
            this.serviceAdditonalService = serviceAdditonalService;
            this.serviceShipmentWeight = serviceShipmentWeight;
            this.serviceShipment = serviceShipment;
            this.serviceAddionalServiceShipment = serviceAddionalServiceShipment;
            this.serviceStatus = serviceStatus;
            this.serviceStatusShipment = serviceStatusShipment;
        }

        [Authorize(Roles = "User")]
        public IActionResult Create()
        {
            try
            {
                List<AdditionalService> additionalServicesList = serviceAdditonalService.GetAll();
                List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

                List<ShipmentWeight> shipmentWeightList = serviceShipmentWeight.GetAll();
                List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

                CreateShipmentViewModel model = new CreateShipmentViewModel
                {
                    AdditionalServices = selectAdditionalServicesList,
                    ShipmentWeights = selectShipmentWeightList
                };

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult Create(CreateShipmentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<AdditionalService> additionalServicesList = serviceAdditonalService.GetAll();
                    List<SelectListItem> selectAdditionalServicesList = additionalServicesList.Select(s => new SelectListItem { Text = s.AdditionalServiceName + " - " + s.AdditionalServicePrice + " RSD", Value = s.AdditionalServiceId.ToString() }).ToList();

                    List<ShipmentWeight> shipmentWeightList = serviceShipmentWeight.GetAll();
                    List<SelectListItem> selectShipmentWeightList = shipmentWeightList.Select(s => new SelectListItem { Text = s.ShipmentWeightDescpription, Value = s.ShipmentWeightId.ToString() }).ToList();

                    model.AdditionalServices = selectAdditionalServicesList;
                    model.ShipmentWeights = selectShipmentWeightList;

                    return View(model);
                }

                Shipment shipment = new Shipment
                {
                    ShipmentWeightId = model.ShipmentWeightId,
                    ShipmentContent = model.ShipmentContent,
                    ContactPersonName = model.ContactPersonName,
                    ContactPersonPhone = model.ContactPersonPhone,
                    Note = model.Note,
                    Sending  = new Address
                    {
                        City = model.SendingCity,
                        Street = model.SendingAddress,
                        PostalCode = model.SendingPostalCode
                    },
                    Receiving = new Address
                    {
                        City = model.ReceivingCity,
                        Street = model.ReceivingAddress,
                        PostalCode = model.ReceivingPostalCode
                    },
                    DelivererId = 3
                };

                Random rand = new Random();
                const string chars = "0123456789QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
                shipment.ShipmentCode = new string(Enumerable.Repeat(chars, 11)
                                                              .Select(s => s[rand.Next(chars.Length)])
                                                              .ToArray());


                int userId = -1;
                int.TryParse(userManager.GetUserId(HttpContext.User), out userId);

                if (userId != -1)
                {
                    shipment.CustomerId = userId;
                }

                double weightPrice = serviceShipmentWeight.FindByID(model.ShipmentWeightId).ShipmentWeightPrice;
                double additionalServicesPrice = 0;

                if (model.Services != null && model.Services.Count() > 0)
                {
                    List<AdditionalService> additionalServices = serviceAdditonalService.GetAll();

                    foreach (AdditonalServiceViewModel sa in model.Services)
                    {
                        additionalServicesPrice += additionalServices.Find(s => s.AdditionalServiceId == sa.AdditionalServiceId).AdditionalServicePrice;
                    }
                }

                shipment.Price = weightPrice + additionalServicesPrice;

                serviceShipment.Add(shipment);

                foreach (AdditonalServiceViewModel sa in model.Services)
                {
                    AdditionalServiceShipment ass = new AdditionalServiceShipment();
                    ass.AdditionalServiceId = sa.AdditionalServiceId;
                    ass.ShipmentId = shipment.ShipmentId;
                    serviceAddionalServiceShipment.Add(ass);
                }

                StatusShipment ss = new StatusShipment
                {
                    ShipmentId = shipment.ShipmentId,
                    StatusId = serviceStatus.GetByName("Scheduled").StatusId,
                    StatusTime = DateTime.Now
                };

                serviceStatusShipment.Add(ss);

                return RedirectToAction("CustomerShipments");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult AddService(int additionalServiceId, int number)
        {
            try
            {
                AdditionalService service = serviceAdditonalService.FindByID(additionalServiceId);

                AdditonalServiceViewModel model = new AdditonalServiceViewModel
                {
                    AdditionalServiceId = service.AdditionalServiceId,
                    AddtionalServiceName = service.AdditionalServiceName,
                    AdditonalServicePrice = service.AdditionalServicePrice,
                    Sn = number
                };

                return PartialView(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult CustomerShipments()
        {
            try
            {
                var userId = int.Parse(userManager.GetUserId(HttpContext.User));

                List<Shipment> model = serviceShipment.GetAllOfSpecifiedUser(userId);

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [Authorize(Roles = "Deliverer")]
        public IActionResult AllShipments()
        {
            List<Shipment> model = serviceShipment.GetAll();

            return View(model);
        }

        [Authorize(Roles = "User, Deliverer")]
        public IActionResult ShipmentMonitoring()
        {
            ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult ShipmentMonitoring(ShipmentMonitoringViewModel model)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByCode(model.ShipmentCode);

                if(shipment == null)
                {
                    ModelState.AddModelError(string.Empty, "The shipment code you entered does not exist. Please check your code and try again.");
                    return View("ShipmentMonitoring");
                }

                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);

                List<Status> statusesList = serviceStatus.GetAll();

                foreach (StatusShipment ss in statusShipmentList)
                {
                    StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                    {
                        StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                        StatusTime = ss.StatusTime
                    };
                    model.ShipmentStatuses.Add(ssvm);
                }

                return View("ShipmentStatuses", model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [Authorize(Roles = "Deliverer")]
        [HttpGet]
        public IActionResult EditStatus(int id)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByID(id);

                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);
                List<Status> statusesList = serviceStatus.GetAll();
                List<SelectListItem> statusesSelectList = statusesList.Select(s => new SelectListItem { Text = s.StatusName, Value = s.StatusId.ToString() }).ToList();

                ShipmentMonitoringViewModel model = new ShipmentMonitoringViewModel
                {
                    ShipmentCode = shipment.ShipmentCode,
                    StatusesSelect = statusesSelectList
                };

                foreach (StatusShipment ss in statusShipmentList)
                {
                    StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                    {
                        StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                        StatusTime = ss.StatusTime
                    };
                    model.ShipmentStatuses.Add(ssvm);
                }

                return View(model);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult EditStatus(int id, ShipmentMonitoringViewModel model)
        {
            try
            {
                Shipment shipment = serviceShipment.FindByID(id);
                List<StatusShipment> statusShipmentList = serviceStatusShipment.GetAllByShipmentId(shipment.ShipmentId);

                if(statusShipmentList.Any(ss => ss.StatusId == model.StatusId))
                {
                    ModelState.AddModelError(string.Empty, "You cannot add a status that is already in the shipment status list.");

                    List<Status> statusesList = serviceStatus.GetAll();
                    List<SelectListItem> statusesSelectList = statusesList.Select(s => new SelectListItem { Text = s.StatusName, Value = s.StatusId.ToString() }).ToList();

                    ShipmentMonitoringViewModel m = new ShipmentMonitoringViewModel
                    {
                        ShipmentCode = shipment.ShipmentCode,
                        StatusesSelect = statusesSelectList
                    };

                    foreach (StatusShipment ss in statusShipmentList)
                    {
                        StatusShipmentViewModel ssvm = new StatusShipmentViewModel
                        {
                            StatusName = statusesList.Find(sl => sl.StatusId == ss.StatusId).StatusName,
                            StatusTime = ss.StatusTime
                        };
                        m.ShipmentStatuses.Add(ssvm);
                    }

                    return View(m);
                }

               serviceStatusShipment.Add(new StatusShipment
                {
                    ShipmentId = id,
                    StatusId = model.StatusId,
                    StatusTime = DateTime.Now
                });


                return RedirectToAction("EditStatus");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { Message = ex.Message });
            }
        }
    }   
}
