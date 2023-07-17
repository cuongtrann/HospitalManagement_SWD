﻿using HospitalManagement.Business.IService;
using HospitalManagement.DataAccess.IRepository;
using HospitalManagement.DataAccess.Models;
using HospitalManagement.DataAccess.Repository;

namespace HospitalManagement.Business.Service
{
    public class InvoiceService : IInvoiceService
    {
        SWD392_DBContext context;

        IInvoiceRepository invoiceRepository;

        IInvoiceDetailRepository invoiceDetailRepository;

        IServiceRepository serviceRepository;

        public InvoiceService(SWD392_DBContext context)
        {
            this.context = context;
            invoiceRepository = new InvoiceRepository(context);
            invoiceDetailRepository = new InvoiceDetailRepository(context);
            serviceRepository = new ServiceRepository(context);
        }

        public void CreateInvoice(int examinationCardId)
        {
            Invoice invoice = new Invoice();
            invoice.MedicalExaminationCardId = examinationCardId;
            invoice.CreateAt = DateTime.Now;
            invoice.Status = false;
            invoice.InsuranceInfo = "N/A";
            invoice.PaymentMethod = "Credit Card";

            decimal? totalCost = 0;
            List<InvoiceDetail> invoiceDetails = invoiceDetailRepository.GetInvoiceDetailsByExaminationCard(examinationCardId);
            invoiceDetails.ForEach(invoiceDetail =>
            {
                var service = serviceRepository.GetService((int)invoiceDetail.ServiceId);
                totalCost += service.Price;
            });

            invoice.TotalCost = totalCost;

            invoiceRepository.CreateInvoice(invoice);
        }
    }
}