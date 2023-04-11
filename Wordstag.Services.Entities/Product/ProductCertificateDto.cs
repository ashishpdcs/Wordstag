using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordstag.Domain.Entities.Product;

namespace Wordstag.Services.Entities.Product
{
    public class ProductCertificateDto
    {
        public Guid ProductCertificateId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Noofapplicants { get; set; }
        public bool? Requiredservices { get; set; }
        public bool? DocumentsApostilled { get; set; }
        public bool? CanadaImmigrationVisa { get; set; }
        public int? NotarizedAndCertyIndianAddressId { get; set; }
        public bool? NotarizedTranslation { get; set; }
        public int? RequireHardCopyId { get; set; }
        public string? CourierServiceAddress { get; set; }
        public int? NeedApostilleId { get; set; }
        public bool? CourierEntireIndianAddress { get; set; }
        public string? AvailingApostilleService { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SaveProductCertificateDto
    {
        public Guid ProductCertificateId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Noofapplicants { get; set; }
        public bool? Requiredservices { get; set; }
        public bool? DocumentsApostilled { get; set; }
        public bool? CanadaImmigrationVisa { get; set; }
        public int? NotarizedAndCertyIndianAddressId { get; set; }
        public bool? NotarizedTranslation { get; set; }
        public int? RequireHardCopyId { get; set; }
        public string? CourierServiceAddress { get; set; }
        public int? NeedApostilleId { get; set; }
        public bool? CourierEntireIndianAddress { get; set; }
        public string? AvailingApostilleService { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
    }

    public class GetProductCertificateDto
    {
        public Guid ProductCertificateId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Noofapplicants { get; set; }
        public bool? Requiredservices { get; set; }
        public bool? DocumentsApostilled { get; set; }
        public bool? CanadaImmigrationVisa { get; set; }
        public int? NotarizedAndCertyIndianAddressId { get; set; }
        public bool? NotarizedTranslation { get; set; }
        public int? RequireHardCopyId { get; set; }
        public string? CourierServiceAddress { get; set; }
        public int? NeedApostilleId { get; set; }
        public bool? CourierEntireIndianAddress { get; set; }
        public string? AvailingApostilleService { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public string? NotarizedAndCertyIndianAddressDetails { get; set; }
        public decimal? NotarizedAndCertyIndianAddressAmount { get; set; }
        public string? RequiredHardCopyDetails { get; set; }
        public decimal? RequiredHardCopyAmount { get; set; }
        public string? NeedApostilleDetails { get; set; }
        public decimal? NeedApostilleAmount { get; set; }
    }

    public class UpdateProductCertificateDto
    {
        public Guid ProductCertificateId { get; set; }
        public Guid? ProductId { get; set; }
        public int? Noofapplicants { get; set; }
        public bool? Requiredservices { get; set; }
        public bool? DocumentsApostilled { get; set; }
        public bool? CanadaImmigrationVisa { get; set; }
        public int? NotarizedAndCertyIndianAddressId { get; set; }
        public bool? NotarizedTranslation { get; set; }
        public int? RequireHardCopyId { get; set; }
        public string? CourierServiceAddress { get; set; }
        public int? NeedApostilleId { get; set; }
        public bool? CourierEntireIndianAddress { get; set; }
        public string? AvailingApostilleService { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedBy { get; set; }
        
    }

    public class DeleteProductCertificateDto
    {
        public Guid ProductCertificateId { get; set; }
        

    }
}
