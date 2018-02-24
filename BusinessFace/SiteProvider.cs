using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer;
using Zensoft.Website.DataLayer.DAO;

namespace Zensoft.Website.BusinessLayer
{
    class SiteProvider
    {
        private static ArticlesDAO _articlesDAO = null;
        private static CategoriesDAO _categoriesDAO = null;
        private static SuperCategoriesDAO _superCategoriesDAO = null;
        private static FeedbacksDAO _feedbacksDAO = null;
        private static PollsDAO _pollsDAO = null;
        private static PollOptionsDAO _pollOptionsDAO = null;
        private static ArticleHighlightsDAO _articleHighlightsDAO = null;
        private static CommentsDAO _commentsDAO = null;

        private static AdLinksDAO _adLinksDAO = null;
        private static AdLocationsDAO _adLocationsDAO = null;

        private static SuppliersDAO _suppliersDAO = null;
        private static PCategoriesDAO _pCategoriesDAO = null;

        private static ProductsDAO _productsDAO = null;
        private static DepartmentsDAO _departmentsDAO = null;
        private static SuperDepartmentsDAO _superDepartmentsDAO = null;

        private static ProductImagesDAO _productImagesDAO = null;
        private static SupplierPricesDAO _supplierPricesDAO = null;
        private static SpecialsDAO _specialsDAO = null;
        private static ProductSpecialsDAO _productSpecialsDAO = null;
        private static ProductCommentsDAO _productCommentsDAO = null;
        private static ProductPropertiesDAO _productPropertiesDAO = null;

        private static PropertiesGroupsDAO _propertiesGroupsDAO = null;
        private static PropertiesDAO _propertiesDAO = null;
        private static PropertiesValuesDAO _propertiesValuesDAO = null;

        private static BrandsDAO _brandsDAO = null;
        private static BrandDepartmentsDAO _brandDepartmentsDAO = null;

        private static PriceDistanceDAO _priceDistanceDAO = null;
        private static PriceDepartmentDAO _priceDepartmentDAO = null;

        private static OrderItemsDAO _orderItemsDAO = null;
        private static OrdersDAO _ordersDAO = null;
        private static OrderStatusDAO _orderStatusDAO = null;
        private static PaymentMethodsDAO _paymentMethodsDAO = null;

        private static UserPMessagesDAO _userPMessagesDAO = null;
        private static PMessagesDAO _pMessagesDAO = null;


        private static ActivityLogsDAO _activityLogsDAO = null;

        private static AlbumDAO _albumDAO = null;
        private static AlbumImageDAO _imageDAO = null;

        private static LikeDAO _likeDAO = null;

        private static VCategoriesDAO _vCategoriesDAO = null;
        private static VideosDAO _videosAO = null;

        private static CitiesDAO _citiesDAO = null;
        private static DirectionDAO _directionDAO = null;

        #region Article
        public static ArticleHighlightsDAO ArticleHighlightsProvider
        {
            get
            {
                if (_articleHighlightsDAO == null) _articleHighlightsDAO = new ArticleHighlightsDAO();
                return _articleHighlightsDAO;
            }
        }

        public static ArticlesDAO ArticlesProvider
        {
            get
            {
                if (_articlesDAO == null) _articlesDAO = new ArticlesDAO();
                return _articlesDAO;
            }
        }

        public static CategoriesDAO CategoriesProvider
        {
            get
            {
                if (_categoriesDAO == null) _categoriesDAO = new CategoriesDAO();
                return _categoriesDAO;
            }
        }

        public static SuperCategoriesDAO SuperCategoriesProvider
        {
            get
            {
                if (_superCategoriesDAO == null) _superCategoriesDAO = new SuperCategoriesDAO();
                return _superCategoriesDAO;
            }
        }        
        #endregion

        #region Extension
        public static ActivityLogsDAO ActivityLogsProvider
        {
            get
            {
                if (_activityLogsDAO == null) _activityLogsDAO = new ActivityLogsDAO();
                return _activityLogsDAO;
            }
        }
        public static FeedbacksDAO FeedbacksProvider
        {
            get
            {
                if (_feedbacksDAO == null) _feedbacksDAO = new FeedbacksDAO();
                return _feedbacksDAO;
            }
        }

        public static PollsDAO PollsProvider
        {
            get
            {
                if (_pollsDAO == null) _pollsDAO = new PollsDAO();
                return _pollsDAO;
            }
        }

        public static PollOptionsDAO PollOptionsProvider
        {
            get
            {
                if (_pollOptionsDAO == null) _pollOptionsDAO = new PollOptionsDAO();
                return _pollOptionsDAO;
            }
        }

        public static CommentsDAO CommentsProvider
        {
            get
            {
                if (_commentsDAO == null) _commentsDAO = new CommentsDAO();
                return _commentsDAO;
            }
        }

        public static AdLinksDAO AdLinksProvider
        {
            get
            {
                if (_adLinksDAO == null) _adLinksDAO = new AdLinksDAO();
                return _adLinksDAO;
            }
        }
        public static AdLocationsDAO AdLocationsProvider
        {
            get
            {
                if (_adLocationsDAO == null) _adLocationsDAO = new AdLocationsDAO();
                return _adLocationsDAO;
            }
        }

        #endregion

        #region Products
        public static ProductCommentsDAO ProductCommentsProvider
        {
            get
            {
                if (_productCommentsDAO == null) _productCommentsDAO = new ProductCommentsDAO();
                return _productCommentsDAO;
            }
        }
        public static PCategoriesDAO PCategoriesProvider
        {
            get
            {
                if (_pCategoriesDAO == null) _pCategoriesDAO = new PCategoriesDAO();
                return _pCategoriesDAO;
            }
        }

        public static ProductSpecialsDAO ProductSpecialsProvider
        {
            get
            {
                if (_productSpecialsDAO == null) _productSpecialsDAO = new ProductSpecialsDAO();
                return _productSpecialsDAO;
            }
        }

        public static SpecialsDAO SpecialsProvider
        {
            get
            {
                if (_specialsDAO == null) _specialsDAO = new SpecialsDAO();
                return _specialsDAO;
            }
        }

        public static SupplierPricesDAO SupplierPricesProvider
        {
            get
            {
                if (_supplierPricesDAO == null) _supplierPricesDAO = new SupplierPricesDAO();
                return _supplierPricesDAO;
            }
        }

        public static ProductImagesDAO ProductImagesProvider
        {
            get
            {
                if (_productImagesDAO == null) _productImagesDAO = new ProductImagesDAO();
                return _productImagesDAO;
            }
        }

        public static SuppliersDAO SuppliersProvider
        {
            get
            {
                if (_suppliersDAO == null) _suppliersDAO = new SuppliersDAO();
                return _suppliersDAO;
            }
        }

        public static ProductsDAO ProductsProvider
        {
            get
            {
                if (_productsDAO == null) _productsDAO = new ProductsDAO();
                return _productsDAO;
            }
        }

        public static DepartmentsDAO DepartmentsProvider
        {
            get
            {
                if (_departmentsDAO == null) _departmentsDAO = new DepartmentsDAO();
                return _departmentsDAO;
            }
        }

        public static SuperDepartmentsDAO SuperDepartmentsProvider
        {
            get
            {
                if (_superDepartmentsDAO == null) _superDepartmentsDAO = new SuperDepartmentsDAO();
                return _superDepartmentsDAO;
            }
        }

        public static ProductPropertiesDAO ProductPropertiesProvider
        {
            get
            {
                if (_productPropertiesDAO == null) _productPropertiesDAO = new ProductPropertiesDAO();
                return _productPropertiesDAO;
            }
        }
        #endregion

        #region Property for product
        public static PropertiesGroupsDAO PropertiesGroupsProvider
        {
            get
            {
                if (_propertiesGroupsDAO == null) _propertiesGroupsDAO = new PropertiesGroupsDAO();
                return _propertiesGroupsDAO;
            }
        }

        public static PropertiesDAO PropertiesProvider
        {
            get
            {
                if (_propertiesDAO == null) _propertiesDAO = new PropertiesDAO();
                return _propertiesDAO;
            }
        }

        public static PropertiesValuesDAO PropertiesValuesProvider
        {
            get
            {
                if (_propertiesValuesDAO == null) _propertiesValuesDAO = new PropertiesValuesDAO();
                return _propertiesValuesDAO;
            }
        }
        #endregion

        #region brand for department
        public static BrandsDAO BrandsProvider
        {
            get
            {
                if (_brandsDAO == null) _brandsDAO = new BrandsDAO();
                return _brandsDAO;
            }
        }

        public static BrandDepartmentsDAO BrandDepartmentsProvider
        {
            get
            {
                if (_brandDepartmentsDAO == null) _brandDepartmentsDAO = new BrandDepartmentsDAO();
                return _brandDepartmentsDAO;
            }
        }
        #endregion

        #region price for department
        public static PriceDistanceDAO PriceDistanceProvider
        {
            get
            {
                if (_priceDistanceDAO == null) _priceDistanceDAO = new PriceDistanceDAO();
                return _priceDistanceDAO;
            }
        }

        public static PriceDepartmentDAO PriceDepartmentProvider
        {
            get
            {
                if (_priceDepartmentDAO == null) _priceDepartmentDAO = new PriceDepartmentDAO();
                return _priceDepartmentDAO;
            }
        }
        #endregion

        #region Orders
        public static OrderItemsDAO OrderItemsProvider
        {
            get
            {
                if (_orderItemsDAO == null) _orderItemsDAO = new OrderItemsDAO();
                return _orderItemsDAO;
            }
        }
        public static OrdersDAO OrdersProvider
        {
            get
            {
                if (_ordersDAO == null) _ordersDAO = new OrdersDAO();
                return _ordersDAO;
            }
        }
        public static OrderStatusDAO OrderStatusProvider
        {
            get
            {
                if (_orderStatusDAO == null) _orderStatusDAO = new OrderStatusDAO();
                return _orderStatusDAO;
            }
        }
        public static PaymentMethodsDAO PaymentMethodsProvider
        {
            get
            {
                if (_paymentMethodsDAO == null) _paymentMethodsDAO = new PaymentMethodsDAO();
                return _paymentMethodsDAO;
            }
        }
        #endregion

        #region Community

        public static PMessagesDAO PMessagesProvider
        {
            get
            {
                if (_pMessagesDAO == null) _pMessagesDAO = new PMessagesDAO();
                return _pMessagesDAO;
            }
        }
        public static UserPMessagesDAO UserPMessagesProvider
        {
            get
            {
                if (_userPMessagesDAO == null) _userPMessagesDAO = new UserPMessagesDAO();
                return _userPMessagesDAO;
            }
        }
        #endregion

        #region Album
        public static AlbumDAO AlbumProvider
        {
            get
            {
                if (_albumDAO == null) _albumDAO = new AlbumDAO();
                return _albumDAO;
            }
        }
        public static AlbumImageDAO AlbumImageProvider
        {
            get
            {
                if (_imageDAO == null) _imageDAO = new AlbumImageDAO();
                return _imageDAO;
            }
        }

        #endregion

        #region Like
        public static LikeDAO LikeProvider
        {
            get
            {
                if (_likeDAO == null) _likeDAO = new LikeDAO();
                return _likeDAO;
            }
        }
        #endregion

        #region Video
        public static VCategoriesDAO VCategoriesProvider
        {
            get
            {
                if (_vCategoriesDAO == null) _vCategoriesDAO = new VCategoriesDAO();
                return _vCategoriesDAO;
            }
        }
        public static VideosDAO VideosProvider
        {
            get
            {
                if (_videosAO == null) _videosAO = new VideosDAO();
                return _videosAO;
            }
        }
        #endregion

        #region Cities
        public static CitiesDAO CitiesProvider
        {
            get
            {
                if (_citiesDAO == null) _citiesDAO = new CitiesDAO();
                return _citiesDAO;
            }
        }
        #endregion

        #region Direction
        public static DirectionDAO DirectionProvider
        {
            get
            {
                if (_directionDAO == null) _directionDAO = new DirectionDAO();
                return _directionDAO;
            }
        }
        #endregion
    }
}
