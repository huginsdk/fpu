#pragma once

#include <string>
#include <map>

using namespace std;

class ProgramConfig
{
	public:
		static int LOGO_LINE_LENGTH;
		static int PRODUCT_NAME_LENGTH;
		static int PLU_NAME_FIXLENGTH;
		static int CREDIT_NAME_LENGTH;
		static int FCURRENCY_NAME_LENGTH;
		static int DEP_NAME_LENGTH;
		static int LENGTH_OF_LOGO_LINES;
		static int MAX_CREDIT_COUNT;
		static int MAX_FCURRENCY_COUNT;
		static int MAX_VAT_RATE_COUNT;
		static int MAX_DEPARTMENT_COUNT;
		static int MAX_SUB_CAT_COUNT;
		static int MAX_MAIN_CATEGORY_COUNT;
		static int MAX_CASHIER_COUNT;

		static int AMOUNT_LENGTH;

		static int STX;
		static int ETX;

		static int FPU_CMD_TIMEOUT;
		static int FPU_RPRT_TIMEOUT;
		static int FPU_SRV_TIMEOUT;
		static int FPU_START_FM_TIMEOUT;
		static int FPU_EFT_PAYMENT_TIMEOUT;
};

class GMPConstants
{
	public:
		static int LEN_SERIAL;
		static int LEN_EX_SERIAL;
		static int LEN_SEQUENCE;
		static int LEN_DATE;
		static int LEN_TIME;
		static int LEN_RESP_CODE;
		static int LEN_DATA_TAG;
		static int LEN_GRUP_TAG;
		static int LEN_FISCAL_COMMAND;
		static int LEN_LENGTH;
		static int LEN_RANDOM_NUMBER;
		static int LEN_VERSION;
};

class FPUCommonTags
{
 	public:
		static int FPU_FISCAL_COMMAND;
};

class GMPCommonTags
{
	public:
	    static int TAG_SEQUNCE;
		static int TAG_OP_DATE;
		static int TAG_OP_TIME;
		static int TAG_RESP_CODE;
};

class GMPGrupTags
{
	public:
		static int DG_HEADER;
		static int DG_BLOCK;
		static int DG_MATCH;
};

class GMPDataTags
{
 	public:
		static int DT_HOSTLOCALIP;
		static int DT_IP;
		static int DT_BRAND;
		static int DT_MODEL;
		static int DT_SERIAL;

		static int DT_ECR_BRAND;
		static int DT_ECR_MODEL;
		static int DT_ECR_SERIAL;
		static int DT_RANDOM_NUMBER;
		static int DT_ECR_RANDOM_NUMBER;

		static int DT_MOD_KEY;
		static int DT_EXP_KEY;
		static int DT_ENC_KEY;
		static int DT_CHK_VAL;
		
		static int DT_ECR_CERT;
		static int DT_EXT_DH_PUB_KEY;
		static int DT_ERROR_CODE;
		static int DT_ECR_POS_INDEX;
		static int DT_SIGNATURE_OF_A;
		static int DT_DRIVER_VERSION;
		static int DT_DH_P;
		static int DT_DH_G;
		static int DT_DH_CHECK_HASH;
};

class FPUGroupTags
{
	public:
		static int DETAIL;
		static int SALE;
		static int VOID1;
		static int TOTALS;
		static int PAYMENT;
		static int END;
		static int FILE;
		static int DISCOUNT;
		static int NOTES;
		static int PARAMS;
		static int EFT;
};

class FPUDataTags
{
	public:
		static int DEPT; // Departman numarası
		static int PLU; // Plu Numarası
		static int QUANTITY; // Miktar/Count
		static int AMOUNT; // Fiyat/Price
		static int PAYMENT_TYPE; // Ödeme Tipi
		static int PART_NUM; // Blok no(büyük mesajlar için)
		static int TOTAL_PART; // Toplam blok sayısı
		static int FILE_NAME; // Dosya adı
		static int DOC_TYPE; // Belge Tipi (Fiş, Fatura,...)
		static int REG_ID; // Kasaya özel numara
		static int CASHIER_ID; // Kasiyer numarası
		static int BARCODE; // Barkod bilgisi (Ürün barkodu...)
		static int DOCUMENT_NUM; // Fiş numarası
		static int DOC_SERIAL; // Seri no (Örn: Fatura seri no)
		static int INSTALL_NUM; // Taksit
		static int INDEX; // İndeks (Kredi no,logo no)
		static int PERCENTAGE; // Yüzde (indirim, kdv)
		static int ENDOFMSG; // Paket sonu
		static int PAY_REFCODE; // Ödeme referans kodu
		static int VATGROUP_NO; // Kdv grubu numarası
		static int CATEGORY_NO; // Ana ürün grubu numarası
		static int SUBCATEGORY_NO; // Alt ürün grubu numarası
		static int LAST_PART; // Son paket olduğunu gösterir
		static int NOTE; // Metin alanı (ürün adı, satır vs)
		static int SALE_REFCODE; // Satış kalemine varsa harici ref kodu. 
		static int PASSWORD; // Şifre
		static int ZNO; // Z Numarası
		static int EJNO; // Ekü Numarası
		static int PROPNAME; // Özellik Adı
		static int PROPVALUE; // Özellik Değeri
		static int ITEMOPTIONS; // Tartılabilirlik,  Fiyatlı Satış gibi departman ve ürün opsiyonları
		static int CMD; // Komut numarası/kodu
		static int ERROR1; // Mali uygulamadan dönen hata kodu
		static int STATE; // Mali uygulamanın durumu
		static int PORT; // Port Numarası
		static int EJ_LIMIT_LINE; // Ekü limit satır sayısı
		static int CASHIER_AUTH; // Kasiyer yetki seviyesi
		static int GRAPHIC_LOGO; // Grafik Logo
		static int TCKN_VKN_LOGO; // Müşteri tc no veya vergi no
		static int PLATE_NUM; // Araç plaka
		static int EFT_PAY_STATE;// Kredi ödeme durum
        static int CARD_HOLDER; // Kredi kartı müşteri adı
		static int CARD_NUMBER; // Kart Numarası
		static int EFT_DISC_ACTIVE; // Ödeme indirim artırım yapılabilir?
        static int HGNCCID; // Hugin card id
        static int HGNCCNAME; // Hugin card name
        static int CHECK_NO; // Çek Numarası
        static int PROVISION_ID; // Provision id
        static int ACQUIER_ID;// Bank Info
		static int ISSUER_ID;// Issuer
		static int BATCH_NO; // Batch
		static int STAN_NO;  // Standing

};

class HSMessageTags
{
	public:
		static int INIT_REQ;
		static int INIT_RESP;
		static int KEY_EX_REQ;
		static int KEY_EX_RESP;
		static int CLOSE_REQ;
		static int CLOSE_RESP;
		static int ECHO_REQ;
		static int ECHO_RESP;
};

class POSMessageTags
{
	public:
		static int BANK_LIST;
};

class POSDataTags
{
	public:
		static int APP_LIST;
		static int APP_BKM_ID;
		static int APP_STATUS;
		static int APP_PRIORITY;
};

class GMPResCodes
{
	public:
		static string SUCCESS;//    Operation successful
		static string UNREG_SERIAL;//03  Unregistered terminal serial
		static string INV_OPERATION;//12  Invalid Operation
		static string SEQNUM_NOT_UNIQUE;//80  Sequence number not unique
		static string SYSTEM_BUSY;//91  System busy
		static string SYSTEM_ERROR;//96  System error
		static string TIMEOUT; //99 Timeout
};

enum State
{
    ST_IDLE = 1,
    ST_SELLING,
    ST_SUBTOTAL,
    ST_PAYMENT,
    ST_OPEN_SALE,
    ST_INFO_RCPT,
    ST_CUSTOM_RCPT,
    ST_IN_SERVICE,
    ST_SRV_REQUIRED,
    ST_LOGIN,
    ST_NONFISCAL,
    ST_ON_PWR_RCOVR,
    ST_INVOICE,
    ST_CONFIRM_REQUIRED
};

class Utililty
{
	private:
		static wstring stateMessages[];
		public:
			static wstring GetErrorMessage(int errorCode);
			static wstring GetStateMessage(State state);
};

