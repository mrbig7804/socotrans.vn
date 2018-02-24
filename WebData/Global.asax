<%@ application language="C#" %>

<script runat="server">

    /// <summary>
    /// Lưu lại trạng thái số người online và visited vào file text
    /// </summary>
    void saveSatus()
    {
        System.IO.StreamWriter sw = null;
        try
        {
            string path = Server.MapPath("~/log/status.txt");
            sw = System.IO.File.CreateText(path);

            sw.WriteLine(Application["UserOnline"].ToString());
            sw.WriteLine(Application["UserVisited"].ToString());

            sw.Flush();
        }
        catch (Exception err)
        {
            //lỗi không ghi được vào file
        }
        finally
        {
            if (sw != null)
            {
                sw.Close();
            }
        }

    }

    /// <summary>
    /// Lấy trạng thái số người online và visited từ file text
    /// </summary>
    void getStatus()
    {
        //Open the file to read from.
        System.IO.StreamReader sr = null;

        try
        {
            string path = Server.MapPath("~/log/status.txt");
            sr = System.IO.File.OpenText(path);

            string s = "";
            if ((s = sr.ReadLine()) != null)
            {
                //Application["UserOnline"] = Convert.ToInt32(s);
            }

            if ((s = sr.ReadLine()) != null)
            {
                Application["UserVisited"] = Convert.ToInt32(s);
            }
        }
        catch (Exception err)
        {
            //lỗi không ghi được vào file
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
    }
    private static void RegisterRoutes()
    {
        //System.Web.Routing.RouteTable.Routes.Add(
        //    "shop",
        //    new System.Web.Routing.Route("shop/{name}",
        //              new ShopRouteHandler(
        //                  "~/shop.aspx")));
        //routes.Add(new Route("{resource}.axd/{*pathInfo}", new StopRoutingHandler()));

        System.Web.Routing.RouteTable.Routes.Add(new System.Web.Routing.Route("{resource}.axd/{*pathInfo}", new System.Web.Routing.StopRoutingHandler()));

        System.Web.Routing.RouteTable.Routes.Add(
            "showitem",
            new System.Web.Routing.Route("showitem/{name}",
                      new ShowItemRouteHandler(
                          "~/showitem.aspx")));
        
        System.Web.Routing.RouteTable.Routes.Add(
            "showitem2",
            new System.Web.Routing.Route("san-pham/{name}",
                      new ShowItemRouteHandler(
                          "~/showitem.aspx")));

        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "trangchu1",
                "trang-chu/",
                "~/default.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "gioithieu",
                "gioi-thieu/",
                "~/about.aspx" //page
                ); 
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                 "bando",
                 "ban-do/",
                 "~/ban-do.aspx" //page
                 );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "camnang",
                "cam-nang/",
                "~/cam-nang.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "camnang1",
                "cam-nang/{catID}/{title}",
                "~/cam-nang1.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "cauhoithuonggap",
                "cau-hoi-thuong-gap/",
                "~/faqs.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "ynghiacacloaihoa",
                "y-nghia-cac-loai-hoa/",
                "~/y-nghia-cac-loai-hoa.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "banggia",
                "bang-gia/",
                "~/bang-gia.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "dichvu",
                "dich-vu/",
                "~/dich-vu.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "tintuc",
                "tin-tuc/",
                "~/tin-tuc.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "tuvankhachhang",
                "tu-van-khach-hang/",
                "~/tu-van-khach-hang.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "thuvienvideo",
                "thu-vien-video/",
                "~/videos.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "thuvienvideo1",
                "thu-vien-video/{catID}/{videoID}/{title}",
                "~/videos.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "thuvienanh",
                "thu-vien-anh/",
                "~/albums.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "thuvienanh1",
                "thu-vien-anh/{albumID}/{title}",
                "~/showAlbum.aspx" //page
                );      
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "baiviet",
                "bai-viet/{articleID}/{title}",
                "~/showarticle.aspx" //page
        );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "lienhe",
                "lien-he/",
                "~/feedback.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "dangnhap",
                "dang-nhap/",
                "~/login.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "dangky",
                "dang-ky/",
                "~/register.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "dangtin",
                "dang-tin/",
                "~/person/PostingProduct.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "dangtin1",
                "dang-tin/{messenger}",
                "~/dang-tin.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "thanhtoandonhang",
                "thanh-toan-don-hang/",
                "~/ShoppingCart.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "gui-don-hang",
                "gui-don-hang/",
                "~/ShoppingMss.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "timkiem",
                "ket-qua-tim-kiem/",
                "~/ResultSearching.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "sanpham",
                "san-pham/",
                "~/sanpham.aspx" //page
                );
        System.Web.Routing.RouteTable.Routes.MapPageRoute(
                "san-pham1",
                "san-pham/{departmentID}/{title}",
                "~/sanpham1.aspx" //page
                );
    }

    //private static void RegisterRoutes( System.Web.Routing.RouteCollection routes)
    //{

    //    routes.MapPageRoute(
    //        "product-department",
    //        "san-pham/{superdepartment}",
    //        "~/shopping.aspx" //page
    //        );

    //}

    void Application_Start(object sender, EventArgs e)
    {
        RegisterRoutes();
        //RegisterRoutes(System.Web.Routing.RouteTable.Routes);

        Application["UserOnline"] = 0;
        Application["UserVisited"] = 0;
        getStatus();


        //Ghi vào file log khi ứng dụng bắt đâu chạy
        System.IO.StreamWriter myStreamWriter = null;
        try
        {
            myStreamWriter = System.IO.File.AppendText(Server.MapPath("~/log/ApplicationLog.txt"));

            myStreamWriter.Write(DateTime.Now.ToString() + ": Application: Started. \r\n");

            myStreamWriter.Flush();

        }
        catch (Exception exc)
        {
            //lỗi không ghi được vào file
        }
        finally
        {
            if (myStreamWriter != null)
            {
                myStreamWriter.Close();
            }
        }

    }

    void Application_End(object sender, EventArgs e)
    {

        //ghi vào file log khi ngừng ứng dụng
        System.IO.StreamWriter myStreamWriter = null;
        try
        {
            myStreamWriter = System.IO.File.AppendText(Server.MapPath("~/log/ApplicationLog.txt"));

            myStreamWriter.Write(DateTime.Now.ToString() + ": Application: Stoped. \r\n");

            myStreamWriter.Flush();

        }
        catch (Exception exc)
        {
            //Lỗi không ghi được vào file
        }
        finally
        {
            if (myStreamWriter != null)
            {
                myStreamWriter.Close();
            }
        }
    }

    void Application_Error(object sender, EventArgs e)
    {
        Exception err = Server.GetLastError();

        if ((Context != null) && err.InnerException != null)
        {
            if (Context.User.IsInRole("Administrators"))
            {
                Response.Clear();
                Response.Write("<h1>" + err.InnerException.Message + "</h1>");
                Response.Write("<pre>" + err.ToString() + "</pre>");
                Server.ClearError();
            }

            //Ghi lỗi vào file
            System.IO.StreamWriter myStreamWriter = null;
            try
            {
                myStreamWriter = System.IO.File.AppendText(Server.MapPath("~/log/Error" + DateTime.Now.ToString("yyMMdd") + ".txt"));

                myStreamWriter.Write("\r\n" + DateTime.Now.ToString() + "\r\n" + err.InnerException.Message + "\r\n" + err.ToString() + "\r\n" + "\r\n");

                myStreamWriter.Flush();

            }
            catch (Exception exc)
            {
                //Lỗi không ghi được vào file
            }
            finally
            {
                if (myStreamWriter != null)
                {
                    myStreamWriter.Close();
                }
            }
        }
    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started
        Application.Lock();

        if ((Int32)Application["UserOnline"] <= 0)
            getStatus();

        Application["UserOnline"] = (Int32)Application["UserOnline"] + 1;
        Application["UserVisited"] = (Int32)Application["UserVisited"] + 1;
        Application.UnLock();

        saveSatus();

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        Application.Lock();

        //getStatus();

        Application["UserOnline"] = (Int32)Application["UserOnline"] - 1;
        Application.UnLock();

        //saveSatus();
    }

</script>

