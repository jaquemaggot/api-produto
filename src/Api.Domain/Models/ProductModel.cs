using System;

namespace Api.Domain.Models
{
    public class ProductModel
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private int? _height;
        public int? Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int? _width;
        public int? Width
        {
            get { return _width; }
            set { _width = value; }
        }

        private int? _length;
        public int? Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private decimal? _weight;
        public decimal? Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }

        private string _gtin;
        public string Gtin
        {
            get { return _gtin; }
            set { _gtin = value; }
        }

        private decimal? _value;
        public decimal? Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private DateTime _acquisitionDate;
        public DateTime AcquisitionDate
        {
            get { return _acquisitionDate; }
            set { _acquisitionDate = value; }
        }

        private string _imagebase64;
        public string ImageBase64
        {
            get { return _imagebase64; }
            set { _imagebase64 = value; }
        }
    }
}
