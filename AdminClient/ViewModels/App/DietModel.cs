using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace AdminClient.ViewModels.App
{
    public class DietDataModel
    {
        public List<DietModel> data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
    }
    public class DietModel
    {

        public int DIETMasterId { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int BedId { get; set; }
        public string BedNo { get; set; }
        public string FoodType { get; set; }
        public string SpecialInstruction { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
       
        public bool IsAllocated { get; set; }
        public string DoctorName { get; set; }
        public string QrCode
        {
            get
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(DIETMasterId.ToString(), QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20);

                System.IO.MemoryStream ms = new MemoryStream();
                qrCodeImage.Save(ms, ImageFormat.Png);
                byte[] byteImage = ms.ToArray();
                var SigBase64 = Convert.ToBase64String(byteImage); 
                                string detailspageUrl = "data:image/png;base64," + SigBase64;


                return detailspageUrl;
            }
        }

    }
}
