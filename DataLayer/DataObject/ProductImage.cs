using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ProductImage
    {
        protected int _productImageID;
        protected int _productID;
        protected string _smallImage = String.Empty;
        protected string _medImage = String.Empty;
        protected string _fullImage = String.Empty;

        public ProductImage()
        {
        }

        public ProductImage(int productImageID, int productID, string smallImage, string medImage, string fullImage)
        {
            _productImageID = productImageID;
            _productID = productID;
            _smallImage = smallImage;
            _medImage = medImage;
            _fullImage = fullImage;
        }

        #region Public Properties

        public int ProductImageID
        {
            get { return _productImageID; }
            set { _productImageID = value; }
        }

        public int ProductID
        {
            get { return _productID; }
            set { _productID = value; }
        }

        public string SmallImage
        {
            get { return _smallImage; }
            set { _smallImage = value; }
        }

        public string MedImage
        {
            get { return _medImage; }
            set { _medImage = value; }
        }

        public string FullImage
        {
            get { return _fullImage; }
            set { _fullImage = value; }
        }
        #endregion
    }


}
