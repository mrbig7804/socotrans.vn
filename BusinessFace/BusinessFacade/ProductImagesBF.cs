using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class ProductImagesBF
    {

        protected int _productImageID;
        protected int _productID;
        protected string _smallImage = String.Empty;
        protected string _medImage = String.Empty;
        protected string _fullImage = String.Empty;

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

        private static List<ProductImagesBF> GetProductImagesBFListFromProductImagesList(List<ProductImage> recordset)
        {
            List<ProductImagesBF> ret = new List<ProductImagesBF>();
            foreach (ProductImage record in recordset)
                ret.Add(GetProductImagesBFFromProductImage(record));
            return ret;
        }

        private static ProductImagesBF GetProductImagesBFFromProductImage(ProductImage record)
        {
            if (record == null)
                return null;
            else
            {
                return new ProductImagesBF(record.ProductImageID, record.ProductID, record.SmallImage, record.MedImage, record.FullImage);
            }
        }

        public ProductImagesBF()
        {
        }


        public ProductImagesBF(int productImageID, int productID, string smallImage, string medImage, string fullImage)
        {
            _productImageID = productImageID;
            _productID = productID;
            _smallImage = smallImage;
            _medImage = medImage;
            _fullImage = fullImage;
        }

        public static ProductImagesBF GetProductImagesBF(int productImageID)
        {
            return GetProductImagesBFFromProductImage(SiteProvider.ProductImagesProvider.GetProductImage(productImageID));
        }

        //Get by ForeignKey
        public static List<ProductImagesBF> GetProductImagesByProductID(int productID)
        {
            return GetProductImagesBFListFromProductImagesList(SiteProvider.ProductImagesProvider.GetProductImagesByProductID(productID));
        }

        //Get All
        public static List<ProductImagesBF> GetProductImagesAll()
        {
            return GetProductImagesBFListFromProductImagesList(SiteProvider.ProductImagesProvider.GetProductImagesAll());
        }

        //Insert
        public int Insert()
        {
            return ProductImagesBF.Insert(this.ProductImageID, this.ProductID, this.SmallImage, this.MedImage, this.FullImage);
        }

        //Update
        public bool Update()
        {
            return ProductImagesBF.Update(this.ProductImageID, this.ProductID, this.SmallImage, this.MedImage, this.FullImage);
        }

        //Delete
        public bool Delete()
        {
            return ProductImagesBF.Delete(this.ProductImageID);
        }

        //Insert
        public static int Insert(int productImageID, int productID, string smallImage, string medImage, string fullImage)
        {
            return SiteProvider.ProductImagesProvider.Insert(new ProductImage(productImageID, productID, smallImage, medImage, fullImage));
        }

        //Update
        public static bool Update(int productImageID, int productID, string smallImage, string medImage, string fullImage)
        {
            return SiteProvider.ProductImagesProvider.Update(new ProductImage(productImageID, productID, smallImage, medImage, fullImage));
        }

        //Delete
        public static bool Delete(int productImageID)
        {
            

            return SiteProvider.ProductImagesProvider.Delete(productImageID);
        }

    }

}
