using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;


namespace FP300Service
{
    public enum StatusCode
    {
        [Description("ECR has no sale")]
        ST_IDLE = 1,

        [Description("On selling (Ex: cannot get report)")]
        ST_SELLING = 2,

        [Description("Subtotal calculated.")]
        ST_SUBTOTAL = 3,

        [Description("Waiting for payment (ex: cannot sell)")]
        ST_PAYMENT = 4,

        [Description("Receipt have to close. Payment is done.")]
        ST_OPEN_SALE = 5,

        [Description("On receiving info receipt")]
        ST_INFO_RCPT = 6,

        [Description("On custom receipt mdoe")]
        ST_CUSTOM_RCPT = 7,

        [Description("In service menu")]
        ST_IN_SERVICE = 8,

        [Description("Service required")]
        ST_SRV_REQUIRED = 9,

        [Description("Cashier login has not been done.")]
        ST_LOGIN = 10,

        [Description("ECR is not fiscal (Ex. EJ reports cannot get)")]
        ST_NONFISCAL = 11,

        [Description("there is a document which waiting for void")]
        ST_ON_PWR_RCOVR = 12,

        [Description("On invoice")]
        ST_INVOICE = 13,

        [Description("ECR waiting for confirm")]
        ST_CONFIRM_REQUIRED = 14,
    }
}