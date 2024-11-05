using RetailClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Project3
{
    public partial class HomeAdd : System.Web.UI.Page
    {
        Agent agent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["agent"] != null)
            {
                agent = (Agent)Session["agent"];

                if (!IsPostBack)
                {
                    ViewState["RoomsCount"] = 1;
                    ViewState["UtilitiesCount"] = 1;
                    ViewState["AmenitiesCount"] = 1;
                    ViewState["ImagesCount"] = 1;
                    foreach (PropertyType type in Enum.GetValues(typeof(PropertyType)))
                    {
                        ddlPropertyType.Items.Add(type.ToString());
                    }
                    foreach (GarageType type in Enum.GetValues(typeof(GarageType)))
                    {
                        ddlGarageType.Items.Add(type.ToString());
                    }
                    foreach (SaleStatus type in Enum.GetValues(typeof(SaleStatus)))
                    {
                        ddlSaleStatus.Items.Add(type.ToString());
                    }
                    foreach (CoolingTypes type in Enum.GetValues(typeof(CoolingTypes)))
                    {
                        ddlCooling.Items.Add(type.ToString());
                    }
                    foreach (HeatingTypes type in Enum.GetValues(typeof(HeatingTypes)))
                    {
                        ddlHeating.Items.Add(type.ToString());
                    }
                }
                if (ViewState["RoomsCount"] != null)
                {
                    int roomsCount = (int)ViewState["RoomsCount"];
                    for (int i = 0; i < roomsCount; i++)
                    {
                        GenerateRoom(i);
                    }
                }
                if (ViewState["UtilitiesCount"] != null)
                {
                    int utilitiesCount = (int)ViewState["UtilitiesCount"];
                    for (int i = 0; i < utilitiesCount; i++)
                    {
                        GenerateUtility(i);
                    }
                }
                if (ViewState["AmenitiesCount"] != null)
                {
                    int amenitiesCount = (int)ViewState["AmenitiesCount"];
                    for (int i = 0; i < amenitiesCount; i++)
                    {
                        GenerateAmenity(i);
                    }
                }
                if (ViewState["ImagesCount"] != null)
                {
                    int imagesCount = (int)ViewState["ImagesCount"];
                    for (int i = 0; i < imagesCount; i++)
                    {
                        GenerateImage(i);
                    }
                }
            }
        }

        protected void btnDashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        // Room
        protected void GenerateRoom(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlRoomContainer{count}";
            panel.CssClass = "item-container";

            Label lblHeight = new Label();
            lblHeight.ID = $"lblHeight{count}";
            lblHeight.Text = "Height: ";
            TextBox txtHeight = new TextBox();
            txtHeight.ID = $"txtHeight{count}";
            txtHeight.Attributes["Placeholder"] = "Enter Height";

            Label lblWidth = new Label();
            lblWidth.ID = $"lblWidth{count}";
            lblWidth.Text = "Width: ";
            TextBox txtWidth = new TextBox();
            txtWidth.ID = $"txtWidth{count}";
            txtWidth.Attributes["Placeholder"] = "Enter Width";

            Label lblRoomType = new Label();
            lblRoomType.ID = $"lblRoomType{count}";
            lblRoomType.Text = "RoomType: ";
            DropDownList ddlRoomType = new DropDownList();
            ddlRoomType.ID = $"ddlRoomType{count}";
            foreach (RoomType type in Enum.GetValues(typeof(RoomType)))
            {
                ddlRoomType.Items.Add(type.ToString());
            }

            Button btnDelete = new Button();
            btnDelete.ID = $"btnRoomDelete_{count}";
            btnDelete.Text = "Delete";
            btnDelete.Click += new EventHandler(btnDeleteRoom_Click);

            panel.Controls.Add(lblHeight);
            panel.Controls.Add(txtHeight);
            panel.Controls.Add(lblWidth);
            panel.Controls.Add(txtWidth);
            panel.Controls.Add(lblRoomType);
            panel.Controls.Add(ddlRoomType);
            panel.Controls.Add(btnDelete);
            phRooms.Controls.Add(panel);
        }
        protected void btnGenerateRoom_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["RoomsCount"];
            GenerateRoom(count);
            ViewState["RoomsCount"] = count + 1;
        }
        protected void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            string roomDivID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlRoomContainer{roomDivID}").Visible = false;
        }
        //Utility
        protected void GenerateUtility(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlUtilityContainer{count}";
            panel.CssClass = "item-container";

            Label lblInformation = new Label();
            lblInformation.ID = $"lblInformation{count}";
            lblInformation.Text = "Information: ";
            TextBox txtInformation = new TextBox();
            txtInformation.ID = $"txtInformation{count}";
            txtInformation.Attributes["Placeholder"] = "Enter Information";

            DropDownList ddlUtilityType = new DropDownList();
            ddlUtilityType.ID = $"ddlUtilityType{count}";
            foreach (UtilityTypes type in Enum.GetValues(typeof(UtilityTypes)))
            {
                ddlUtilityType.Items.Add(type.ToString());
            }

            Button btnDelete = new Button();
            btnDelete.ID = $"btnUtilityDelete_{count}";
            btnDelete.Text = "Delete";
            btnDelete.Click += new EventHandler(btnDeleteUtility_Click);

            panel.Controls.Add(lblInformation);
            panel.Controls.Add(txtInformation);
            panel.Controls.Add(ddlUtilityType);
            panel.Controls.Add(btnDelete);
            phUtilities.Controls.Add(panel);
        }
        protected void btnGenerateUtility_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["UtilitiesCount"];
            GenerateUtility(count);
            ViewState["UtilitiesCount"] = count + 1;
        }
        protected void btnDeleteUtility_Click(object sender, EventArgs e)
        {
            string roomDivID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlUtilityContainer{roomDivID}").Visible = false;
        }
        //Amenity
        protected void GenerateAmenity(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlAmenityContainer{count}";
            panel.CssClass = "item-container";

            Label lblDescription = new Label();
            lblDescription.ID = $"lblDescription{count}";
            lblDescription.Text = "Description: ";
            TextBox txtDescription = new TextBox();
            txtDescription.ID = $"txtDescription{count}";
            txtDescription.Attributes["Placeholder"] = "Enter Description";

            DropDownList ddlAmenityType = new DropDownList();
            ddlAmenityType.ID = $"ddlAmenityType{count}";
            foreach (AmenityType type in Enum.GetValues(typeof(AmenityType)))
            {
                ddlAmenityType.Items.Add(type.ToString());
            }

            Button btnDelete = new Button();
            btnDelete.ID = $"btnAmenityDelete_{count}";
            btnDelete.Text = "Delete";
            btnDelete.Click += new EventHandler(btnDeleteAmenity_Click);

            panel.Controls.Add(lblDescription);
            panel.Controls.Add(txtDescription);
            panel.Controls.Add(ddlAmenityType);
            panel.Controls.Add(btnDelete);
            phAmenities.Controls.Add(panel);
        }
        protected void btnGenerateAmenity_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["AmenitiesCount"];
            GenerateAmenity(count);
            ViewState["AmenitiesCount"] = count + 1;

        }
        protected void btnDeleteAmenity_Click(object sender, EventArgs e)
        {
            string roomDivID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlAmenityContainer{roomDivID}").Visible = false;
        }
        //Image
        protected void GenerateImage(int count)
        {
            Panel panel = new Panel();
            panel.ID = $"pnlImageContainer{count}";
            panel.CssClass = "item-container";

            if (count == 0)
            {
                Literal litMainImage = new Literal();
                litMainImage.ID = $"lblImageType{count}";
                litMainImage.Text = "<h2>Main Image</h2>";
                panel.Controls.Add(litMainImage);
            }

            Label lblImageDescription = new Label();
            lblImageDescription.ID = $"lblImageDescription{count}";
            lblImageDescription.Text = "Description: ";
            TextBox txtImageDescription = new TextBox();
            txtImageDescription.ID = $"txtImageDescription{count}";
            txtImageDescription.Attributes["Placeholder"] = "Enter Description";

            Label lblImageRoomType = new Label();
            lblImageRoomType.ID = $"lblImageRoomType{count}";
            lblImageRoomType.Text = "Room Type: ";
            DropDownList ddlImageRoomType = new DropDownList();
            ddlImageRoomType.ID = $"ddlImageRoomType{count}";
            foreach (RoomType type in Enum.GetValues(typeof(RoomType)))
            {
                ddlImageRoomType.Items.Add(type.ToString());
            }

            FileUpload fuImage = new FileUpload();
            fuImage.ID = $"fuImage{count}";

            Button btnDelete = new Button();
            btnDelete.ID = $"btnImageDelete_{count}";
            btnDelete.Text = "Delete";
            btnDelete.Click += new EventHandler(btnDeleteImage_Click);


            panel.Controls.Add(lblImageDescription);
            panel.Controls.Add(txtImageDescription);
            panel.Controls.Add(lblImageRoomType);
            panel.Controls.Add(ddlImageRoomType);
            panel.Controls.Add(fuImage);
            panel.Controls.Add(btnDelete);

            phImages.Controls.Add(panel);
        }
        protected void btnGenerateImage_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["ImagesCount"];
            GenerateImage(count);
            ViewState["ImagesCount"] = count + 1;
        }
        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            string roomDivID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlImageContainer{roomDivID}").Visible = false;
        }

        //ONLY ADD WHERE VISIBILITY IS TRUE
        protected bool AddHomeValidate()
        {
            return true;
        }

        protected void btnSubmitHomeListing_Click(object sender, EventArgs e)
        {
            //if (!AddHomeValidate())
            //{
                //error
            //}
            HomeImages homeImages = new HomeImages();
            for (int i = 0; i < (int)ViewState["ImagesCount"]; i++)
            {
                TextBox txtImageDescription = (TextBox)phImages.FindControl($"txtImageDescription{i}");
                DropDownList ddlImageRoomType = (DropDownList)phImages.FindControl($"ddlImageRoomType{i}");
                FileUpload fuImage = (FileUpload)phImages.FindControl($"fuImage{i}");
                bool isMainImage = (Literal)phImages.FindControl($"lblImageType{i}") != null;
                //===========================================STORE IMAGE============================================================
                int imageSize = fuImage.PostedFile.ContentLength;
                byte[] imageData = new byte[imageSize];
                fuImage.PostedFile.InputStream.Read(imageData, 0, imageSize);

                string imageName = fuImage.FileName;
                string imageType = fuImage.PostedFile.ContentType;

                string fileExtension = imageName.Substring(imageName.LastIndexOf(".")).ToLower();

                if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".bmp" || fileExtension == ".gif")
                {
                    string fileName = $"{ddlImageRoomType.SelectedValue}_{DateTime.Now.Ticks}{fileExtension}";
                    string sourceFile = Server.MapPath("FileStorage/");
                    string destinationFile = Server.MapPath($"FileStorage/{fileName}");
                    string url = $"https://cis-iis2.temple.edu/Fall2024/CIS3342_tui78495/Project3/FileStorage/{destinationFile}";
                    fuImage.SaveAs(sourceFile + fileName);
                    homeImages.Add(new RetailClassLibrary.Image(url, (RoomType)Enum.Parse(typeof(RoomType), ddlImageRoomType.SelectedValue), txtImageDescription.Text, isMainImage));
                }
                else
                {
                    //error
                }
            }
            HomeAmenities homeAmenities = new HomeAmenities();
            for (int i = 0; i < (int)ViewState["AmenitiesCount"]; i++)
            {
                TextBox txtAmenityDescription = (TextBox)phAmenities.FindControl($"txtDescription{i}");
                DropDownList ddlAmenityRoomType = (DropDownList)phAmenities.FindControl($"ddlAmenityType{i}");
                homeAmenities.Add(new Amenity((AmenityType)Enum.Parse(typeof(AmenityType), ddlAmenityRoomType.SelectedValue), txtAmenityDescription.Text));
            }
            HomeRooms homeRooms = new HomeRooms();
            for (int i = 0; i < (int)ViewState["RoomsCount"]; i++)
            {
                TextBox txtHeight = (TextBox)phRooms.FindControl($"txtHeight{i}");
                TextBox txtWidth = (TextBox)phRooms.FindControl($"txtWidth{i}");
                DropDownList ddlRoomType = (DropDownList)phRooms.FindControl($"ddlRoomType{i}");
                homeRooms.Add(new Room((RoomType)Enum.Parse(typeof(RoomType), ddlRoomType.SelectedValue), int.Parse(txtHeight.Text), int.Parse(txtWidth.Text)));
            }
            HomeUtilities homeUtilities = new HomeUtilities();
            for (int i = 0; i < (int)ViewState["UtilitiesCount"]; i++)
            {
                TextBox txtInformation = (TextBox)phUtilities.FindControl($"txtInformation{i}");
                DropDownList ddlUtilityType = (DropDownList)phUtilities.FindControl($"ddlUtilityType{i}");
                homeUtilities.Add(new Utility((UtilityTypes)Enum.Parse(typeof(UtilityTypes), ddlUtilityType.SelectedValue), txtInformation.Text));
            }
            Home home = new Home
            (
                agent,
                int.Parse(txtHomeCost.Text),
                new Address(txtHomeState.Text, txtHomeCity.Text, txtHomeStreet.Text, txtHomeZipCode.Text),
                (PropertyType)Enum.Parse(typeof(PropertyType), ddlPropertyType.SelectedValue),
                int.Parse(txtYearConstructed.Text),
                (GarageType)Enum.Parse(typeof(GarageType), ddlGarageType.SelectedValue),
                txtHomeDescription.Text,
                DateTime.Now,
                (SaleStatus)Enum.Parse(typeof(SaleStatus), ddlSaleStatus.SelectedValue),
                homeImages,
                homeAmenities,
                new TemperatureControl((HeatingTypes)Enum.Parse(typeof(HeatingTypes), ddlHeating.SelectedValue), (CoolingTypes)Enum.Parse(typeof(CoolingTypes), ddlCooling.SelectedValue)),
                homeRooms,
                homeUtilities
            );
            RetailHelper.CreateNewHome(home);
        }
    }
}