using RealEstateClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace Project3
{
    public partial class HomeAdd : System.Web.UI.Page
    {
        Agent agent;
        HomeImages homeImages;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["agent"] != null)
            {
                agent = (Agent)Session["agent"];
                if (ViewState["HomeImages"] != null)
                {
                    homeImages.List = (List<RealEstateClassLibrary.Image>)ViewState["HomeImages"];
                }

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
            string divID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlRoomContainer{divID}").Visible = false;
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

            Label lblUtilityType = new Label();
            lblUtilityType.ID = $"lblUtilityType{count}";
            lblUtilityType.Text = "Utility Type: ";
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
            panel.Controls.Add(lblUtilityType);
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

            Label lblAmenityType = new Label();
            lblAmenityType.ID = $"lblAmenityType{count}";
            lblAmenityType.Text = "Amenity Type: ";

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
            panel.Controls.Add(lblAmenityType);
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
            string divID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlAmenityContainer{divID}").Visible = false;
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
            Label lblImageUpload = new Label();
            lblImageUpload.ID = $"lblImageUpload{count}";
            lblImageUpload.Text = "Image Upload: ";

            FileUpload fuImage = new FileUpload();
            fuImage.ID = $"fuImage{count}";

            Button btnUpload = new Button();
            btnUpload.ID = $"btnUpload_{count}";
            btnUpload.Text = "Upload";
            btnUpload.Click += new EventHandler(btnUploadImage_Click);

            Label lblImageError = new Label();
            lblImageError.ID = $"lblImageError{count}";
            lblImageError.CssClass = "error";
            lblImageError.Visible = false;

            panel.Controls.Add(lblImageDescription);
            panel.Controls.Add(txtImageDescription);
            panel.Controls.Add(lblImageRoomType);
            panel.Controls.Add(ddlImageRoomType);
            panel.Controls.Add(fuImage);
            panel.Controls.Add(btnUpload);
            panel.Controls.Add(lblImageError);

            phImages.Controls.Add(panel);
        }
        protected void btnGenerateImage_Click(object sender, EventArgs e)
        {
            int count = (int)ViewState["ImagesCount"];
            GenerateImage(count);
            ViewState["ImagesCount"] = count + 1;
        }
        //Takes an images and uploads it. stores Image data in view state
        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            string divID = ((Button)sender).ID.Split('_').Last();
            FileUpload fuImage = (FileUpload)phImages.FindControl($"fuImage{divID}");
            if (((TextBox)phImages.FindControl($"txtImageDescription{divID}")).Text.Length <= 0)
            {
                Label error = (Label)phImages.FindControl($"lblImageError{divID}");
                error.Visible = true;
                error.Text = "You must provide an image description.";
                return; 
            }
            if (!fuImage.HasFile) 
            {
                Label error = (Label)phImages.FindControl($"lblImageError{divID}");
                error.Visible = true;
                error.Text = "You must choose an image to upload";
                return; 
            }
            string imageName = fuImage.FileName;
            string fileExtension = imageName.Substring(imageName.LastIndexOf(".")).ToLower();
            if (fileExtension == ".jpg" || fileExtension == ".jpeg")
            {
                TextBox txtImageDescription = (TextBox)phImages.FindControl($"txtImageDescription{divID}");
                DropDownList ddlImageRoomType = (DropDownList)phImages.FindControl($"ddlImageRoomType{divID}");
                bool isMainImage = (Literal)phImages.FindControl($"lblImageType{divID}") != null;
                int imageSize = fuImage.PostedFile.ContentLength;
                byte[] imageData = new byte[imageSize];
                fuImage.PostedFile.InputStream.Read(imageData, 0, imageSize);
                string fileName = $"{ddlImageRoomType.SelectedValue}_{DateTime.Now.Ticks}{fileExtension}";
                string sourceFile = Server.MapPath("FileStorage/");
                string destinationFile = Server.MapPath($"FileStorage/{fileName}");
                string url = $"https://cis-iis2.temple.edu/Fall2024/CIS3342_tui78495/Project3/FileStorage/{destinationFile}";
                fuImage.SaveAs(sourceFile + fileName);
                //add image to list 
                //change button to delete
                // change txt to lbl ect

                ViewState["HomeImages"] = homeImages;
            } else
            {
                Label error = (Label)phImages.FindControl($"lblImageError{divID}");
                error.Visible = true;
                error.Text = "You must choose a valid image type (.jpg .jpeg)";
                return; 
            }
            fuImage.Visible = false;
        }
        protected void btnDeleteImage_Click(object sender, EventArgs e)
        {
            string divID = ((Button)sender).ID.Split('_').Last();
            phRooms.FindControl($"pnlImageContainer{divID}").Visible = false;
        }

        //ONLY ADD WHERE VISIBILITY IS TRUE
        protected string Validator()
        {
            string errorString = "";

            errorString += Validation.IsAlphaNumeric(txtHomeStreet.Text) && Validation.IsUnder51Characters(txtHomeStreet.Text) ? string.Empty : "Enter a valid Personal Street</br>";
            errorString += Validation.IsAlphaNumeric(txtHomeCity.Text) && Validation.IsUnder51Characters(txtHomeCity.Text) ? string.Empty : "Enter a valid Personal City</br>";
            errorString += Validation.IsAlphaNumeric(txtHomeState.Text) && Validation.IsUnder51Characters(txtHomeState.Text) ? string.Empty : "Enter a valid Personal State</br>";
            errorString += Validation.IsAlphaNumericWithDash(txtHomeZipCode.Text) && Validation.IsUnder51Characters(txtHomeZipCode.Text) ? string.Empty : "Enter a valid Personal Zip Code</br>";
            errorString += Validation.IsInteger(txtHomeCost.Text) ? string.Empty : "Enter a Valid Home Cost (integer)</br>";
            errorString += Validation.IsValidYear(txtYearConstructed.Text)? string.Empty : $"Enter a Valid Year constructed (1700-{DateTime.Now.Year})</br>";
            errorString += txtHomeDescription.Text.Length > 0 ? string.Empty : "Enter a valid Home Description</br>";

            for(int i=0; i < phRooms.Controls.Count; i++)
            {
                if (phRooms.FindControl($"pnlRoomContainer{i}").Visible)
                {
                    TextBox height = (TextBox)phRooms.FindControl($"txtHeight{i}");
                    TextBox width = (TextBox)phRooms.FindControl($"txtWidth{i}");
                    if (!Validation.IsInteger(height.Text)|| !Validation.IsInteger(width.Text))
                    {
                        errorString += "Enter valid dimentions for rooms</br>";
                        break;
                    }
                }
            }

            for(int i=0; i < phUtilities.Controls.Count; i++)
            {
                if (phRooms.FindControl($"pnlUtilityContainer{i}").Visible)
                {
                    TextBox information = (TextBox)phRooms.FindControl($"txtInformation{i}");
                    if (!Validation.IsAlphaNumeric(information.Text))
                    {
                        errorString += "Enter valid information in Utilities</br>";
                        break;
                    }
                }
            }

            for(int i=0; i < phAmenities.Controls.Count; i++)
            {
                if (phRooms.FindControl($"pnlAmenityContainer{i}").Visible)
                {
                    TextBox description = (TextBox)phRooms.FindControl($"txtDescription{i}");
                    if (!Validation.IsAlphaNumeric(description.Text))
                    {
                        errorString += "Enter valid description in Amenities</br>";
                        break;
                    }
                }
            }

            for(int i=0; i < phImages.Controls.Count; i++)
            {
                if (phRooms.FindControl($"pnlImageContainer{i}").Visible)
                {
                    TextBox description = (TextBox)phRooms.FindControl($"txtImageDescription{i}");
                    if (!Validation.IsAlphaNumeric(description.Text))
                    {
                        errorString += "Enter valid image description</br>";
                    }
                    
                }
            }

            homeImages.List = (List<RealEstateClassLibrary.Image>)ViewState["HomeImages"];
            errorString += homeImages.List.Count <= 0 ? "You must have at least one image</br>" : string.Empty;
            return errorString;
        }

        protected void btnSubmitHomeListing_Click(object sender, EventArgs e)
        {
            string err = Validator();
            if (err.Length > 0)
            {
                lblError.Text = err;
                lblError.Visible = true;
                return;
            }
            HomeImages finalHomeImages = new HomeImages((List<RealEstateClassLibrary.Image>)ViewState["HomeImages"]);
            for (int i = 0; i < (int)ViewState["ImagesCount"]; i++)
            {
                TextBox txtImageDescription = (TextBox)phImages.FindControl($"txtImageDescription{i}");
                DropDownList ddlImageRoomType = (DropDownList)phImages.FindControl($"ddlImageRoomType{i}");
                bool isMainImage = (Literal)phImages.FindControl($"lblImageType{i}") != null;

                FileUpload fuImage = (FileUpload)phImages.FindControl($"fuImage{i}");
                int imageSize = fuImage.PostedFile.ContentLength;
                byte[] imageData = new byte[imageSize];
                fuImage.PostedFile.InputStream.Read(imageData, 0, imageSize);
                string imageName = fuImage.FileName;
                string fileExtension = imageName.Substring(imageName.LastIndexOf(".")).ToLower();
                string fileName = $"{ddlImageRoomType.SelectedValue}_{DateTime.Now.Ticks}{fileExtension}";
                string sourceFile = Server.MapPath("FileStorage/");
                string destinationFile = Server.MapPath($"FileStorage/{fileName}");
                string url = $"https://cis-iis2.temple.edu/Fall2024/CIS3342_tui78495/Project3/FileStorage/{destinationFile}";
                fuImage.SaveAs(sourceFile + fileName);
                homeImages.Add(new RealEstateClassLibrary.Image(url, (RoomType)Enum.Parse(typeof(RoomType), ddlImageRoomType.SelectedValue), txtImageDescription.Text, isMainImage));
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
                finalHomeImages,
                homeAmenities,
                new TemperatureControl((HeatingTypes)Enum.Parse(typeof(HeatingTypes), ddlHeating.SelectedValue), (CoolingTypes)Enum.Parse(typeof(CoolingTypes), ddlCooling.SelectedValue)),
                homeRooms,
                homeUtilities
            );
            RealEstateHelper.CreateNewHome(home);
        }
    }
}