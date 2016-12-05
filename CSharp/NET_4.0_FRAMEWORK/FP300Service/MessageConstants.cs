using System;
using System.Collections.Generic;
using System.Text;

namespace FP300Service
{
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

        public const int STX = 0x02;
        public const int ETX = 0x03;

        public const int FPU_CMD_TIMEOUT = 15000;
        public const int FPU_RPRT_TIMEOUT = 45000;
        public const int FPU_SRV_TIMEOUT = 60000;
        public const int FPU_START_FM_TIMEOUT = 120000;
    }

    public class GMPConstants
    {

        public const int LEN_SERIAL = 0x0C;
        public const int LEN_SEQUENCE = 0x03;
        public const int LEN_DATE = 0x03;
        public const int LEN_TIME = 0x03;
        public const int LEN_RESP_CODE = 0x02;
        public const int LEN_DATA_TAG = 0x03;
        public const int LEN_GRUP_TAG = 0x02;
        public const int LEN_FISCAL_COMMAND = 0x01;

    }

    public class FPUCommonTags
    {
        public const int FPU_FISCAL_COMMAND = 0xDFF021;        
    }
    public class GMPCommonTags
    {
        public const int TAG_SEQUNCE = 0xDF8208;
        public const int TAG_OP_DATE = 0xDF8209;
        public const int TAG_OP_TIME = 0xDF820A;
        public const int TAG_RESP_CODE = 0xDF820D;
    }


    public class GMPGrupTags
    {
        public const int DG_BLOCK = 0xDF40;
    }

    public class GMPDataTags
    {
        public const int DT_HOSTLOCALIP = 0xDFC105;
        public const int DT_IP = 0xDFC106;
        public const int DT_BRAND = 0xDFC107;
        public const int DT_MODEL = 0xDFC108;
        public const int DT_SERIAL = 0xDFC109;

        public const int DT_ECR_BRAND = 0xDFC10A;
        public const int DT_ECR_MODEL = 0xDFC10B;
        public const int DT_ECR_SERIAL = 0xDFC10C;


        public const int DT_MOD_KEY = 0xDFC101;
        public const int DT_EXP_KEY = 0xDFC102;
        public const int DT_ENC_KEY = 0xDFC103;
        public const int DT_CHK_VAL = 0xDFC104;
    }

    public class FPUGroupTags
    {
        public const int DETAIL = 0xDF40;
        public const int SALE = 0xDF71;
        public const int VOID = 0xDF72;
        public const int TOTALS = 0xDF73;
        public const int PAYMENT = 0xDF74;
        public const int END = 0xDF75;
        public const int FILE = 0xDF76;
        public const int DISCOUNT = 0xDF77;
        public const int NOTES = 0xDF78;
        public const int PARAMS = 0xDF79;
    }

    public class FPUDataTags
    {
        public const int DEPT = 0xDFF001; // Departman numarası
        public const int PLU = 0xDFF002; // Plu Numarası
        public const int QUANTITY = 0xDFF003; // Miktar/Count
        public const int AMOUNT = 0xDFF004; // Fiyat/Price
        public const int PAYMENT_TYPE = 0xDFF005; // Ödeme Tipi
        public const int PART_NUM = 0xDFF006; // Blok no(büyük mesajlar için)
        public const int TOTAL_PART = 0xDFF007; // Toplam blok sayısı
        public const int FILE_NAME = 0xDFF008; // Dosya adı
        public const int DOC_TYPE = 0xDFF009; // Belge Tipi (Fiş, Fatura,...)
        public const int REG_ID = 0xDFF00A; // Kasaya özel numara
        public const int CASHIER_ID = 0xDFF00B; // Kasiyer numarası
        public const int BARCODE = 0xDFF00C; // Barkod bilgisi (Ürün barkodu...)
        public const int DOCUMENT_NUM = 0xDFF00D; // Fiş numarası
        public const int DOC_SERIAL = 0xDFF00E; // Seri no (Örn: Fatura seri no)
        public const int INSTALL_NUM = 0xDFF00F; // Taksit
        public const int INDEX = 0xDFF010; // İndeks (Kredi no,logo no)
        public const int PERCENTAGE = 0xDFF011; // Yüzde (indirim, kdv)
        public const int ENDOFMSG = 0xDFF012; // Paket sonu
        public const int PAY_REFCODE = 0xDFF013; // Ödeme referans kodu
        public const int VATGROUP_NO = 0xDFF014; // Kdv grubu numarası
        public const int CATEGORY_NO = 0xDFF015; // Ana ürün grubu numarası
        public const int SUBCATEGORY_NO = 0xDFF016; // Alt ürün grubu numarası
        public const int LAST_PART = 0xDFF017; // Son paket olduğunu gösterir
        public const int NOTE = 0xDFF018; // Metin alanı (ürün adı, satır vs)
        public const int SALE_REFCODE = 0xDFF019; // Satış kalemine varsa harici ref kodu. 
        public const int PASSWORD = 0xDFF01A; // Şifre
        public const int ZNO = 0xDFF01B; // Z Numarası
        public const int EJNO = 0xDFF01C; // Ekü Numarası
        public const int PROPNAME = 0xDFF01D; // Özellik Adı
        public const int PROPVALUE = 0xDFF01E; // Özellik Değeri
        public const int ITEMOPTIONS = 0xDFF01F; // Tartılabilirlik,  Fiyatlı Satış gibi departman ve ürün opsiyonları
        public const int CMD = 0xDFF021; // Komut numarası/kodu
        public const int ERROR = 0xDFF022; // Mali uygulamadan dönen hata kodu
        public const int STATE = 0xDFF023; // Mali uygulamanın durumu
        public const int PORT = (0xDFF024); // Port Numarası
        public const int EJ_LIMIT_LINE = (0xDFF025); // Ekü limit satır sayısı
        public const int CASHIER_AUTH = (0xDFF026); // Kasiyer yetki seviyesi
        public const int GRAPHIC_LOGO = (0xDFF027); // Grafik Logo

    }

    public class GMPResCodes
    {

        public static string SUCCESS = "00";//    Operation successful
        public static string UNREG_SERIAL = "03";//03  Unregistered terminal serial
        public static string INV_OPERATION = "12";//12  Invalid Operation
        public static string SEQNUM_NOT_UNIQUE = "80";//80  Sequence number not unique
        public static string SYSTEM_BUSY = "91";//91  System busy
        public static string SYSTEM_ERROR = "96";//96  System error
    }

    public class Utililty
    {
        private static string[] stateMessages =
        {
            "BEKLEMEDE",            /*ST_IDLE*/ 
            "SATIŞ İÇİNDE",         /*ST_SELLING*/ 
            "ARATOPLAM",            /*ST_SUBTOTAL*/
            "ÖDEME BAŞLADI",        /*ST_PAYMENT*/
            "FİŞ KAPAT",            /*ST_OPEN_SALE*/
            "BİLGİ FİŞİ",           /*ST_INFO_RCPT*/
            "ÖZEL FİŞ",             /*ST_CUSTOM_RCPT*/
            "SERVİS BAŞLADI",       /*ST_IN_SERVICE*/
            "SERVİS GEREKLİ",       /*ST_SRV_REQUIRED*/
            "KASİYER GİRİŞİ",       /*ST_LOGIN*/
            "MALİ MODDA DEĞİL",     /*ST_NONFISCAL*/
            "ELEKTRİK KESİNTİSİ",   /*ST_ON_PWR_RCOVR*/
            "FATURA BAŞLADI",       /*ST_INVOICE*/
            "ONAY BEKLEMEKTE",      /*ST_CONFIRM_REQUIRED*/
        };
        private static string[,] errorMessages =
        {
            /*ErrorCode , Message*/
            {"0","İŞLEM BAŞARILI"},
            {"1","VERİ EKSİK GELMİŞ (UZUNLUK KADAR GELMELİ)"},
            {"2","VERİ DEĞİŞMİŞ"},
            {"3","UYGULAMA DURUMU UYGUN DEĞİL"},
            {"4","BÖYLE BİR KOMUT DESTEKLENMİYOR"},
            {"5","PARAMETRE GEÇERSİZ"},
            {"6","OPERASYON BAŞARISIZ"},
            {"7","SİLME GEREKLİ (HATA SONRASI)"},
            {"8","KAĞIT YOK"},
            {"9","CİHAZ EŞLEME YAPILAMADI."},
            {"11","MALİ BELLEK BİLGİLERİ ALINIRKEN HATA OLUŞTU"},
            {"12","MALİ BELLEK TAKILI DEĞİL"},
            {"13","MALİ BELLEK UYUMSUZLUĞU"},
            {"14","MALİ BELLEK FORMATLANMALI"},
            {"15","MALİ BELLEK FORMATLANIRKEN HATA OLUŞTU"},
            {"16","MALİ BELLEK MALİLEŞTİRME YAPILAMADI"},
            {"17","GÜNLÜK Z LİMİT"},
            {"18","MALİ BELLEK DOLDU"},
            {"19","MALİ BELLEK DAHA ÖNCE FORMATLANMIŞ"},
            {"20","MALİ BELLEK KAPATILMIŞ"},
            {"21","GEÇERSİZ MALİ BELLEK"},
            {"22","SERTİFİKALAR YÜKLENEMEDİ"},
            {"31","EKÜ BİLGİLERİ ALINIRKEN HATA OLUŞTU"},
            {"32","EKÜ ÇIKARILDI"},
            {"33","EKÜ KASAYA AİT DEĞİL"},
            {"34","ESKİ EKÜ (SADECE EKÜ RAPORLARI)"},
            {"35","YENİ EKÜ TAKILDI, ONAY BEKLİYOR"},
            {"36","EKÜ DEĞİŞTİRİLEMEZ, Z GEREKLİ"},
            {"37","YENİ EKÜYE GEÇİLEMİYOR"},
            {"38","EKÜ DOLDU, Z GEREKLİ"},
            {"39","EKÜ DAHA ÖNCE FORMATLANMIŞ"},
            {"51","FİŞ LİMİTİ AŞILDI"},
            {"52","FİŞ KALEM ADEDİ AŞILDI"},
            {"53","SATIŞ İŞLEMİ GEÇERSİZ"},
            {"54","İPTAL İŞLEMİ GEÇERSİZ"},
            {"55","DÜZELTME İŞLEMİ YAPILAMAZ"},
            {"56","İNDİRİM/ARTIRIM İŞLEMİ YAPILAMAZ"},
            {"57","ÖDEME İŞLEMİ GEÇERSİZ"},
            {"58","ASGARİ ÖDEME SAYISI AŞILDI"},
            {"59","GÜNLÜK ÜRÜN SATIŞI AŞILDI"},
            {"71","KDV ORANI TANIMSIZ"},
            {"72","KISIM TANIMLANMAMIŞ"},
            {"73","TANIMSIZ ÜRÜN"},
            {"74","KREDİLİ ÖDEME BİLGİSİ EKSİK/GEÇERSİZ"},
            {"75","DÖVİZLİ ÖDEME BİLGİSİ EKSİK/GEÇERSİZ"},
            {"76","EKÜDE KAYIT BULUNAMADI"},
            {"77","MALİ BELLEKTE KAYIT BULUNAMADI"},
            {"78","ALT ÜRÜN GRUBU TANIMLI DEĞİL"},
            {"79","DOSYA BULUNAMADI"},
            {"91","KASİYER YETKİSİ YETERSİZ"},
            {"92","SATIŞ VAR "},
            {"93","SON FİŞ Z DEĞİL "},
            {"94","KASADA YETERLİ PARA YOK"},
            {"95","GÜNLÜK FİŞ SAYISI LİMİT AŞILDI"},
            {"96","GÜNLÜK TOPLAM AŞILDI"},
            {"97","KASA MALİ DEĞİL"},
            {"111","SATIR UZUNLUĞU BEKLENENDEN FAZLA"},
            {"112","KDV ORANI GEÇERSİZ"},
            {"113","DEPT NUMARASI GEÇERSİZ"},
            {"114","PLU NUMARASI GEÇERSİZ"},
            {"115","GEÇERSİZ TANIM (ÜRÜN ADI, KISIM ADI, KREDİ ADI...VS)"},
            {"116","BARKOD GEÇERSİZ"},
            {"117","GEÇERSİZ OPSİYON"},
            {"118","TOPLAM TUTMUYOR"},
            {"119","GEÇERSİZ MİKTAR"},
            {"120","GEÇERSİZ TUTAR"},
            {"121","MALİ NUMARA HATALI"},
            {"131","KAPAKLAR AÇILDI"},
            {"132","MALİ BELLEK MESH ZARAR VERİLDİ"},
            {"133","HUB MESH ZARAR VERİLDİ"},
            {"134","Z ALINMALI(24 SAAT GEÇTİ)"},
            {"135","DOĞRU EKÜ TAK, YENİDEN BAŞLAT"},
            {"136","SERTİFİKA YÜKLENEMEDİ"},
            {"137","TARİH-SAAT AYARLAYIN"},
            {"138","GÜNLÜK İLE MALİ BELLEK UYUMSUZ"},
            {"139","VERİTABANI HATASI"},
            {"140","LOG HATASI"},
            {"141","SRAM HATASI"},
            {"142","SERTİFİKA UYUMSUZ"},
            {"143","VERSİYON HATASI"},
            {"144","GÜNLÜK LOG SAYISI AŞILDI"},
            {"145","YAZARKASAYI YENİDEN BAŞLAT"},
            {"146","KASİYER/SERVİS GÜNLÜK YANLIŞ ŞİFRE GİRİŞİ SAYISINI AŞTI"},            
            {"147","MALİLEŞTİRME YAPILDI. YENİDEN BAŞLAT"},    
            {"148","GİB'e BAĞLANILAMADI. TEKRAR DENE(İŞLEM DURDURMA)"},            
            {"149","SERTİFİKA İNDİRİLDİ. YENİDEN BAŞLAT"},    
            {"150","GÜVENLİ ALAN FORMATLANAMADI"},    
            {"151","JUMPER ÇIKART TAK"}

        };
        public static string GetErrorMessage(int errorCode)
        {
            string msg = "" + errorCode;

            for (int i = 0; i < errorMessages.LongLength; i++)
            {
                if (errorMessages[i,0] == msg)
                {
                    msg = errorMessages[i, 1];
                    break;
                }
            }

            return msg;
        }
        public static string GetStateMessage(State state)
        {
            return stateMessages[((int)state)-1];
        }
    }
}
