using System;
using System.Collections.Generic;
using System.Text;


namespace FP300Service
{
    public static class Common
    {
        public static string[] Payments = { "Nakit", "Kredi", "Çek", "Döviz" };
        public static string[] PaidDocTypes = { "AVANS", "YEMEK FİŞİ"};
    }

    public class FCurrency
    {
        public int ID;
        public string Name;
        public decimal Rate;
    }

    public class ProgramConfig
    {
        public const int LOGO_LINE_LENGTH = (48);
        public const int PRODUCT_NAME_LENGTH = (20);
        public const int PLU_NAME_FIXLENGTH = (15);
        public const int CREDIT_NAME_LENGTH = (15);
        public const int FCURRENCY_NAME_LENGTH = (15);
        public const int DEP_NAME_LENGTH = (20);
        public const int LENGTH_OF_LOGO_LINES = 6;
        public const int MAX_CREDIT_COUNT = 8;
        public const int MAX_FCURRENCY_COUNT = 4;
        public const int MAX_VAT_RATE_COUNT = 8;
        public const int MAX_DEPARTMENT_COUNT = 8;
        public const int MAX_SUB_CAT_COUNT = 250;
        public const int MAX_MAIN_CATEGORY_COUNT = 50;
        public const int MAX_CASHIER_COUNT = 10;

        public const int AMOUNT_LENGTH = 5;

        public const int FPU_CMD_TIMEOUT = 15000;
        public const int FPU_RPRT_TIMEOUT = 45000;
        public const int FPU_SRV_TIMEOUT = 60000;
        public const int FPU_START_FM_TIMEOUT = 120000;
        public const int FPU_EFT_PAYMENT_TIMEOUT = 60000;
    }
}
