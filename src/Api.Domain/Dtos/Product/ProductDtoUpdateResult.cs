using System;
using System.Collections.Generic;
using Api.Domain.Dtos.Category;

namespace Api.Domain.Dtos.Product
{
    public class ProductDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public int? Height { get; set; }

        public int? Width { get; set; }

        public int? Length { get; set; }

        public decimal? Weight { get; set; }

        public string Gtin { get; set; }

        public decimal? Value { get; set; }

        public DateTime? AcquisitionDate { get; set; }

        public string ImageBase64 { get; set; }

        public List<CategoryDto> Categories { get; set; }
    }
}
