namespace Backend.API.Dtos
{
    public class Amount
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    public class Discount
    {
        public Amount amount { get; set; }
        public string rate { get; set; }
        public string type { get; set; }
    }

    public class DiscountTotal
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    public class Invoice
    {
        public string accountid { get; set; }
        public string accounting_systemid { get; set; }
        public string address { get; set; }
        public Amount amount { get; set; }
        public bool auto_bill { get; set; }
        public object autobill_status { get; set; }
        public int basecampid { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        public string country { get; set; }
        public string create_date { get; set; }
        public string created_at { get; set; }
        public string currency_code { get; set; }
        public string current_organization { get; set; }
        public int customerid { get; set; }
        public object date_paid { get; set; }
        public object deposit_amount { get; set; }
        public object deposit_percentage { get; set; }
        public string deposit_status { get; set; }
        public string description { get; set; }
        public Discount discount { get; set; }
        public object discount_description { get; set; }
        public DiscountTotal discount_total { get; set; }
        public string discount_value { get; set; }
        public string display_status { get; set; }
        public object dispute_status { get; set; }
        public string due_date { get; set; }
        public int due_offset_days { get; set; }
        public int estimateid { get; set; }
        public int ext_archive { get; set; }
        public string fname { get; set; }
        public object fulfillment_date { get; set; }
        public object generation_date { get; set; }
        public bool gmail { get; set; }
        public int id { get; set; }
        public string invoice_number { get; set; }
        public int invoiceid { get; set; }
        public string language { get; set; }
        public object last_order_status { get; set; }
        public string lname { get; set; }
        public string lock_status { get; set; }
        public NetPaidAmount net_paid_amount { get; set; }
        public string notes { get; set; }
        public string organization { get; set; }
        public Outstanding outstanding { get; set; }
        public int ownerid { get; set; }
        public Paid paid { get; set; }
        public int parent { get; set; }
        public string payment_details { get; set; }
        public string payment_status { get; set; }
        public object po_number { get; set; }
        public string province { get; set; }
        public object return_uri { get; set; }
        public SenderAddress sender_address { get; set; }
        public int sentid { get; set; }
        public string series { get; set; }
        public bool show_attachments { get; set; }
        public int status { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
        public string template { get; set; }
        public object terms { get; set; }
        public string updated { get; set; }
        public string uuid { get; set; }
        public string v3_status { get; set; }
        public string vat_name { get; set; }
        public string vat_number { get; set; }
        public string version { get; set; }
        public int vis_state { get; set; }
    }

    public class NetPaidAmount
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    public class Outstanding
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    public class Paid
    {
        public string amount { get; set; }
        public string code { get; set; }
    }

    public class Response
    {
        public Result result { get; set; }
    }

    public class Result
    {
        public List<Invoice> invoices { get; set; }
        public int page { get; set; }
        public int pages { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
    }

    public class InvoiceListDto
    {
        public Response response { get; set; }
    }

    public class SenderAddress
    {
        public string city { get; set; }
        public string code { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string street { get; set; }
        public string street2 { get; set; }
    }



}
