namespace Bustop.Hanlders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Web.Script.Serialization;
    using System.Web.SessionState;
    using System.Collections;
    using System.IO;
    using CargoManagementSystem;
    using System.Net;
    using System.Globalization;
    using System.Net.Mime;
    using System.Net.Mail;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;

    /// <summary>
    /// Summary description for Bus
    /// </summary>
    public class Bus : IHttpHandler, IRequiresSessionState
    {
        string username = "";

        public bool IsReusable
        {
            get { return true; }
        }
        class GetJsonData
        {
            public string op { set; get; }
        }
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string op = context.Request["op"];
                switch (op)
                {

                    case "emp_login_click":
                        emp_login_click(context);
                        break;
                    case "GetCsodispatchRoutes":
                        GetCsodispatchRoutes(context);
                        break;
                    case "GetIndentReport":
                        GetIndentReport(context);
                        break;
                    case "GetSalevlue":
                        GetSalevlue(context);
                        break;
                    case "GetmonthwiseSalevlue":
                        GetmonthwiseSalevlue(context);
                        break;
                    case "get_BranchWiseProductsData":
                        get_BranchWiseProductsData(context);
                        break;
                    case "GetCategoryWiseChart":
                        GetCategoryWiseChart(context);
                        break;
                    case "getcheckboxweekdates":
                        getcheckboxweekdates(context);
                        break;

                        
                    case "Getsessionvalues":
                        Getsessionvalues(context);
                        break;
                    case "GetSalesOffice":
                        GetSalesOffice(context);
                        break;
                    case "Get_RaisedVoucherdetails":
                        Get_RaisedVoucherdetails(context);
                        break;
                    case "VoucherApproval":
                        VoucherApproval(context);
                        break;
                    case "VoucherReject":
                        VoucherReject(context);
                        break;
                    case "GetBtnViewVoucherclick":
                        GetBtnViewVoucherclick(context);
                        break;
                    case "GetAppriveSubPaybleValues":
                        GetAppriveSubPaybleValues(context);
                        break;
                    case "GetRouteNameclick":
                        GetRouteNameclick(context);
                        break;
                    case "getAgent_Name":
                        getAgent_Name(context);
                        break;
                    case "Get_lekage_details":
                        Get_lekage_details(context);
                        break;
                    case "GetDCNumbers":
                        GetDCNumbers(context);
                        break;
                    case "GetDCDetails":
                        GetDCDetails(context);
                        break;
                    case "get_ClosingStock_Items":
                        get_ClosingStock_Items(context);
                        break;
                    case "get_Balance_Amount":
                        get_Balance_Amount(context);
                        break;
                    case "get_AgentIncDec":
                        get_AgentIncDec(context);
                        break;
                    //case "get_BranchWiseIndentIncDec":
                    //    get_BranchWiseIndentIncDec(context);
                    //    break;
                    case "GetInventoryDetails":
                        GetInventoryDetails(context);
                        break;
                    case "log_out":
                        log_out(context);
                        break;
                    case "GetDispatchAgents":
                        GetDispatchAgents(context);
                        break;
                    case "GetRouteNameChange":
                        GetRouteNameChange(context);
                        break;
                    case "GetAgents":
                        GetAgents(context);
                        break;
                    case "getBranchValues":
                        getBranchValues(context);
                        break;
                    case "FillCategeoryname":
                        FillCategeoryname(context);
                        break;
                    case "get_product_subcategory_data":
                        get_product_subcategory_data(context);
                        break;
                    case "get_products_data":
                        get_products_data(context);
                        break;
                    case "GetProductNamechange":
                        GetProductNamechange(context);
                        break;
                    case "AddBranchProducts":
                        AddBranchProducts(context);
                        break;
                    case "GetVehicleNos":
                        GetVehicleNos(context);
                        break;
                    case "GetDispatchValues":
                        GetDispatchValues(context);
                        break;
                    case "Get_Employee":
                        Get_Employee(context);
                        break;
                    case "get_Plant_TripRoutes":
                        get_Plant_TripRoutes(context);
                        break;
                    case "Get_CashBook_Details":
                        Get_CashBook_Details(context);
                        break;
                    case "updatesalestypemanage":
                        updatesalestypemanage(context);
                        break;
                    case "GetLineChartValues":
                        GetLineChartValues(context);
                        break;
                    case "GetPieChart_ClassificationType":
                        GetPieChart_ClassificationType(context);
                        break;
                    case "GetLineChart_agentinventorytransactions":
                        GetLineChart_agentinventorytransactions(context);
                        break;
                    case "GetLineChart_agentduetransactions":
                        GetLineChart_agentduetransactions(context);
                        break;
                    case "GetLineChart_classificationindentreport":
                        GetLineChart_classificationindentreport(context);
                        break;
                        //sai
                    case "checkloginstatus":
                        checkloginstatus(context);
                        break;


                    default:
                        var jsonString = String.Empty;
                        context.Request.InputStream.Position = 0;
                        using (var inputStream = new StreamReader(context.Request.InputStream))
                        {
                            jsonString = HttpUtility.UrlDecode(inputStream.ReadToEnd());
                        }
                        if (jsonString != "")
                        {
                            var js = new JavaScriptSerializer();
                            // var title1 = context.Request.Params[1];
                            GetJsonData obj = js.Deserialize<GetJsonData>(jsonString);
                            switch (obj.op)
                            {
                                case "GetweekwiseSalevlue":
                                    GetweekwiseSalevlue(jsonString, context);
                                    break;
                            }
                        }
                        else
                        {
                            var js = new JavaScriptSerializer();
                            var title1 = context.Request.Params[1];
                            GetJsonData obj = js.Deserialize<GetJsonData>(title1);
                            switch (obj.op)
                            {

                                case "btnOrderSaveClick":
                                    btnOrderSaveClick(context);
                                    break;
                                case "get_Plant_Trip_RouteNameChange":
                                    get_Plant_Trip_RouteNameChange(context);
                                    break;
                                case "Gettripinventory_manage":
                                    Gettripinventory_manage(context);
                                    break;
                                case "btnPlantTripSaveClick":
                                    btnPlantTripSaveClick(context);
                                    break;

                            }
                        }
                        break;
                }
            }
            catch
            {
            }
        }
        MySqlCommand cmd;
        VehicleDBMgr vdm;
        class orderdetail
        {
            public string SNo { set; get; }
            public string Product { set; get; }
            public string Productsno { set; get; }
            public string Qty { set; get; }
            public string Rate { set; get; }
            public string Total { set; get; }
            public string ReturnQty { set; get; }
            public string ExtraQty { set; get; }
            public string Status { set; get; }
            public string Unitsqty { set; get; }
            public string UnitCost { set; get; }
            public string IndentNo { set; get; }
            public string hdnSno { set; get; }
            public string orderunitRate { set; get; }
            public string HdnIndentSno { set; get; }
            public string LeakQty { set; get; }
            public string RtnQty { set; get; }
            public string RemainQty { set; get; }
            public string ShortQty { set; get; }
            public string FreeMilk { set; get; }
            public string RemainingQty { set; get; }

        }
        class Orders
        {
            public string op { set; get; }
            public string BranchID { set; get; }
            public List<orderdetail> data { set; get; }
            public List<orderdetail> offerdata { set; get; }
            public List<inventorydetail> invdata { set; get; }
            public string totqty { set; get; }
            public string totrate { set; get; }
            public string totTotal { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string TotalPrice { set; get; }
            public string BalanceAmount { set; get; }
            public string PaidAmount { set; get; }
            public string TotalCost { set; get; }
            public string Remarks { set; get; }
            public string PaymentType { set; get; }
            public string Denominations { set; get; }
            public string ColAmount { set; get; }
            public string SubAmount { set; get; }
            public string IndentType { set; get; }
            public string EmpName { set; get; }
            public string RouteId { set; get; }
            public string SaveType { set; get; }
            public string DispDate { set; get; }
            public string Mode { set; get; }
            public string DispSno { set; get; }
            public string routename { set; get; }
            public string EmpID { set; get; }
            public string DispatchStatus { set; get; }
            public string VehicleNo { set; get; }
            public string Permissions { set; get; }
            public string RemainingQty { set; get; }
            public string i_date { set; get; }
        }
        class Products
        {
            public string ProductName { set; get; }
            public string TotalQty { set; get; }
            public string empid { set; get; }
            public float Avail_prdtQty { set; get; }
            public string Productsno { set; get; }
            public string snoO { set; get; }
            public string tripdata { set; get; }
            public string empname { set; get; }
            public string Cdate { set; get; }
            public string routename { set; get; }
            public string collectedamount { set; get; }
            public string submittedamount { set; get; }
            public string tubs { set; get; }
            public string cans { set; get; }
            public string units { set; get; }
            public string vehcleno { set; get; }
            public string qty { set; get; }
            public string status { set; get; }
            public string VatPercent { set; get; }
            public string KgPrice { set; get; }
            public string extrltrs { set; get; }
        }


        class ReceiptDetails
        {
            public string DispName { set; get; }
            public string RecieptNo { set; get; }
            public string ReceivedAmount { set; get; }
            public string BranchName { set; get; }
            public string opningbalance { set; get; }
        }
        class PaymentDetails
        {
            public string VocherID { set; get; }
            public string Payments { set; get; }
            public string Amount { set; get; }
        }

        class CashBookClass
        {
            public List<ReceiptDetails> ReceiptDetails { set; get; }
            public List<PaymentDetails> PaymentDetails { set; get; }
        }

        private void Get_CashBook_Details(HttpContext context)
        {
            try
            {

                vdm = new VehicleDBMgr();
                DataTable RouteReport = new DataTable();
                DataTable CashPayReport = new DataTable();
                DateTime fromdate = DateTime.Now;
                context.Session["filename"] = "Cash Book ->" + context.Session["branchname"].ToString();
                string BranchID = context.Request["Branchid"];
                string Date = context.Request["Date"];
                DateTime Currentdate = Convert.ToDateTime(Date);
                DataTable dtCashBook = new DataTable();
                RouteReport.Columns.Add("DispName");
                RouteReport.Columns.Add("Reciept No");
                RouteReport.Columns.Add("Received Amount").DataType = typeof(Double);
                if (BranchID == "172" || BranchID == "158")
                {
                }
                else
                {
                    cmd = new MySqlCommand("SELECT dispatch.DispName, tripdata.RecieptNo, tripdata.ReceivedAmount FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN branchdata ON tripdata.BranchID = branchdata.sno WHERE (tripdata.BranchID = @BranchID) AND (tripdata.Cdate BETWEEN @d1 AND @d2) OR (tripdata.Cdate BETWEEN @d1 AND @d2) AND (branchdata.SalesOfficeID = @BranchID)");
                    cmd.Parameters.Add("@BranchID", BranchID);
                    cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                    cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                    dtCashBook = vdm.SelectQuery(cmd).Tables[0];
                }
                cmd = new MySqlCommand("SELECT Branchid, AmountPaid FROM collections WHERE (Branchid = @BranchID) AND (PaidDate BETWEEN @d1 AND @d2)");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(Currentdate).AddDays(-1));
                cmd.Parameters.Add("@d2", GetHighDate(Currentdate).AddDays(-1));
                DataTable dtOpp = vdm.SelectQuery(cmd).Tables[0];
                string opningbalance = "";
                if (dtOpp.Rows.Count > 0)
                {
                    opningbalance = dtOpp.Rows[0]["AmountPaid"].ToString();
                }
                cmd = new MySqlCommand("SELECT Branchid, AmountPaid,VarifyDate FROM collections WHERE (Branchid = @BranchID) AND (PaidDate BETWEEN @d1 AND @d2)");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                DataTable dtclosedtime = vdm.SelectQuery(cmd).Tables[0];
                if (dtclosedtime.Rows.Count > 0)
                {
                    string VarifyDate = dtclosedtime.Rows[0]["VarifyDate"].ToString();
                    DateTime dtVarifyDate = Convert.ToDateTime(VarifyDate);
                    string ChangedTime = dtVarifyDate.ToString("dd/MMM/yyyy HH:MM");
                    //lbl_ClosingDate.Text = ChangedTime;
                }
                foreach (DataRow dr in dtCashBook.Rows)
                {
                    DataRow newrow = RouteReport.NewRow();
                    newrow["DispName"] = dr["DispName"].ToString();
                    newrow["Reciept No"] = dr["RecieptNo"].ToString();
                    double ReceivedAmount = 0;
                    double.TryParse(dr["ReceivedAmount"].ToString(), out ReceivedAmount);
                    string Amount = dr["ReceivedAmount"].ToString();
                    if (Amount == "0")
                    {
                    }
                    else
                    {
                        newrow["Received Amount"] = ReceivedAmount;
                        RouteReport.Rows.Add(newrow);
                    }
                }
                cmd = new MySqlCommand("SELECT Branchid, Amount, Remarks, DOE, Receiptno, Name,PaymentType FROM cashcollections WHERE (Branchid = @Branchid) AND (DOE BETWEEN @d1 AND @d2)  AND (CollectionType = 'Cash')");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                DataTable dtCashCollection = vdm.SelectQuery(cmd).Tables[0];
                if (dtCashCollection.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtCashCollection.Rows)
                    {
                        DataRow newrow = RouteReport.NewRow();
                        string stat = "";
                        if (dr["PaymentType"].ToString() == "Others")
                        {
                            stat = "Oth";
                        }
                        if (dr["PaymentType"].ToString() == "freezer deposit")
                        {
                            stat = "F.D";

                        }
                        newrow["DispName"] = dr["Name"].ToString() + "(" + stat + ")";
                        newrow["Reciept No"] = dr["Receiptno"].ToString();
                        string Amount = dr["Amount"].ToString();
                        if (Amount == "0")
                        {
                        }
                        else
                        {
                            newrow["Received Amount"] = dr["Amount"].ToString();
                            RouteReport.Rows.Add(newrow);
                        }
                    }
                }
                if (BranchID == "172")
                {
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, collections.AmountPaid, collections.ReceiptNo FROM collections INNER JOIN branchdata ON collections.Branchid = branchdata.sno INNER JOIN empmanage ON collections.EmpID = empmanage.Sno WHERE (collections.tripId IS NULL) AND (collections.PaidDate BETWEEN @d1 AND @d2) AND (collections.PaymentType = 'Cash') AND (branchdata.SalesType <> 21) AND (branchdata.SalesType <> 21) AND  (empmanage.Branch = @BranchID)");
                }
                else if (BranchID == "158")
                {
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, cashreceipts.AmountPaid,cashreceipts.PaymentStatus, cashreceipts.Receipt AS ReceiptNo FROM branchdata INNER JOIN cashreceipts ON branchdata.sno = cashreceipts.AgentID WHERE (branchdata.SalesType <> 21) AND (branchdata.SalesType <> 21) AND (cashreceipts.DOE BETWEEN @d1 AND @d2) AND (cashreceipts.BranchId = @BranchID)  order by ReceiptNo");
                }
                else
                {
                    cmd = new MySqlCommand("SELECT branchdata_2.BranchName, collections.AmountPaid, collections.ReceiptNo FROM branchdata INNER JOIN branchdata branchdata_1 ON branchdata.sno = branchdata_1.sno INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SuperBranch INNER JOIN branchdata branchdata_2 ON branchmappingtable.SubBranch = branchdata_2.sno INNER JOIN collections ON branchdata_2.sno = collections.Branchid WHERE (branchdata_1.SalesOfficeID = @BranchID) AND (collections.tripId IS NULL) AND (collections.PaidDate BETWEEN @d1 AND @d2) AND  (collections.PaymentType = 'Cash') OR (branchdata.sno = @BranchID) AND (collections.tripId IS NULL) AND (collections.PaidDate BETWEEN @d1 AND @d2) AND (collections.PaymentType = 'Cash')");
                }
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                DataTable dtAgents = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtAgents.Rows)
                {
                    DataRow newrow = RouteReport.NewRow();
                    string ReceiptNo = dr["ReceiptNo"].ToString();
                    if (ReceiptNo == "")
                    {
                        ReceiptNo = "0";
                    }
                    if (ReceiptNo != "0")
                    {
                        newrow["DispName"] = dr["BranchName"].ToString();
                        newrow["Reciept No"] = dr["ReceiptNo"].ToString();
                        string Amount = dr["AmountPaid"].ToString();
                        if (BranchID == "158")
                        {
                            string PaymentStatus = dr["PaymentStatus"].ToString();

                            if (PaymentStatus == "Incentive" || PaymentStatus == "Cheque" || PaymentStatus == "Bank Trans" || PaymentStatus == "Journal Vo")
                            {
                            }
                            else
                            {
                                if (Amount == "0")
                                {
                                }
                                else
                                {
                                    newrow["Received Amount"] = dr["AmountPaid"].ToString();
                                    RouteReport.Rows.Add(newrow);
                                }
                            }
                        }
                        else
                        {
                            if (Amount == "0")
                            {
                            }
                            else
                            {
                                newrow["Received Amount"] = dr["AmountPaid"].ToString();
                                RouteReport.Rows.Add(newrow);
                            }
                        }
                    }
                }

                List<ReceiptDetails> receiptdetailslist = new List<ReceiptDetails>();
                foreach (DataRow drreceipt in RouteReport.Rows)
                {
                    ReceiptDetails receiptobj = new ReceiptDetails();
                    receiptobj.DispName = drreceipt["DispName"].ToString();
                    receiptobj.RecieptNo = drreceipt["Reciept No"].ToString();
                    receiptobj.ReceivedAmount = drreceipt["Received Amount"].ToString();
                    receiptobj.opningbalance = opningbalance;
                    receiptdetailslist.Add(receiptobj);
                }
                cmd = new MySqlCommand("SELECT CashTo as Payments,ApprovedAmount as Amount,VocherID FROM cashpayables WHERE  (BranchID = @BranchID) AND (DOE BETWEEN @d1 AND @d2) AND (Status = 'P') AND (VoucherType = 'Debit') and (Status <>'C')");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                DataTable dtCashPayble = vdm.SelectQuery(cmd).Tables[0];
                CashPayReport.Columns.Add("Vocher ID");
                CashPayReport.Columns.Add("Payments");
                CashPayReport.Columns.Add("Amount").DataType = typeof(Double);
                foreach (DataRow dr in dtCashPayble.Rows)
                {
                    DataRow newrow = CashPayReport.NewRow();
                    newrow["Vocher ID"] = dr["VocherID"].ToString();
                    newrow["Payments"] = dr["Payments"].ToString();
                    string Amount = dr["Amount"].ToString();
                    if (Amount == "0")
                    {
                    }
                    else
                    {
                        newrow["Amount"] = dr["Amount"].ToString();
                        CashPayReport.Rows.Add(newrow);
                    }
                }
                double DebitCash = 0;
                List<PaymentDetails> paymentdetailslst = new List<PaymentDetails>();
                List<CashBookClass> cashbooklist = new List<CashBookClass>();
                foreach (DataRow drpayment in CashPayReport.Rows)
                {
                    PaymentDetails paymentobj = new PaymentDetails();
                    paymentobj.VocherID = drpayment["Vocher ID"].ToString();
                    paymentobj.Payments = drpayment["Payments"].ToString();
                    paymentobj.Amount = drpayment["Amount"].ToString();
                    paymentdetailslst.Add(paymentobj);
                }
                CashBookClass cashbookobj = new CashBookClass();
                cashbookobj.PaymentDetails = paymentdetailslst;
                cashbookobj.ReceiptDetails = receiptdetailslist;
                cashbooklist.Add(cashbookobj);
                string result = GetJson(cashbooklist);
                context.Response.Write(result);
            }
            catch
            {
            }
        }
        private void GetTripDispPlanDetails(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<tripDespdetail> tripDespdetailList = new List<tripDespdetail>();
                tripDespdetail GettripDesp = new tripDespdetail();
                GettripDesp.DispSno = context.Session["DispSno"].ToString();
                GettripDesp.DispName = context.Session["DispName"].ToString();
                GettripDesp.DispType = context.Session["DispType"].ToString();
                GettripDesp.DispatchStatus = context.Session["DispatchStatus"].ToString();
                GettripDesp.SOBranchId = context.Session["SOBranchId"].ToString();
                GettripDesp.DispatchDate = context.Session["DispatchDate"].ToString();
                GettripDesp.VehicleNo = context.Session["VehicleNo"].ToString();
                GettripDesp.tripid = context.Session["tripid"].ToString();
                tripDespdetailList.Add(GettripDesp);
                string response = GetJson(tripDespdetailList);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class tripDespdetail
        {
            public string DispName { get; set; }
            public string DispType { get; set; }
            public string DispSno { get; set; }
            public string DispatchStatus { get; set; }
            public string SOBranchId { get; set; }
            public string DispatchDate { get; set; }
            public string VehicleNo { get; set; }
            public string tripid { get; set; }
        }
        int dtrowscount = 0;
        DataTable dtallProducts = new DataTable();
        string tripid = "";
        string empid = "";
        string vehcleno = "";
        private void get_Plant_Trip_RouteNameChange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string RouteID = obj.routename;
                empid = obj.EmpID;
                string IndentDate = obj.i_date;
                //string AssignDate = obj.date;
                //string Username = context.Session["userdata_sno"].ToString();
                string salestype = context.Session["salestype"].ToString();
                List<Products> Productslist = new List<Products>();
                string DispatchStatus = obj.DispatchStatus;
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                //string IndentDate = context.Request["i_date"].ToString();
                DateTime Currentdate = Convert.ToDateTime(IndentDate);
                DateTime AssignDate = Convert.ToDateTime(IndentDate);
                string dispdate = context.Session["DispatchDate"].ToString();
                if (dispdate == "0")
                {
                    Currentdate = Currentdate;
                }
                else
                {
                    ServerDateCurrentdate = Currentdate;
                    Currentdate = Currentdate.AddDays(-1);
                }
                string LevelType = context.Session["LevelType"].ToString();
                context.Session["tripid"] = "";
                vehcleno = "";
                int Sno = 0;
                //cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.ProductName, productsdata.Units, invmaster.Qty FROM productsdata INNER JOIN invmaster ON productsdata.Inventorysno = invmaster.sno ORDER BY productsdata.sno");
                cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.ProductName, productsdata.Units, invmaster.Qty FROM productsdata INNER JOIN invmaster ON productsdata.Inventorysno = invmaster.sno INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno WHERE (branchproducts.branch_sno = @BranchID) AND (branchproducts.FLAG=@FLAG) ORDER BY branchproducts.Rank");
                cmd.Parameters.Add("@FLAG", "1");
                cmd.Parameters.Add("@BranchID", context.Session["SOBranchId"].ToString());
                DataTable dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                dtallProducts = new DataTable();
                dtallProducts.Columns.Add("sno");
                dtallProducts.Columns.Add("ProductName");
                dtallProducts.Columns.Add("TotalQty");
                dtallProducts.Columns.Add("Units");
                dtallProducts.Columns.Add("Qty");
                dtallProducts.Columns.Add("Tubs");
                dtallProducts.Columns.Add("Cans");
                foreach (DataRow dr in dtproductsdata.Rows)
                {
                    DataRow newRow = dtallProducts.NewRow();
                    newRow["sno"] = dr["sno"].ToString();
                    newRow["ProductName"] = dr["ProductName"].ToString();
                    newRow["TotalQty"] = "0";
                    newRow["Units"] = dr["Units"].ToString();
                    newRow["Qty"] = dr["Qty"].ToString();
                    newRow["Tubs"] = "0";
                    newRow["Cans"] = "0";
                    dtallProducts.Rows.Add(newRow);
                }
                DateTime todayy = DateTime.Now;
                cmd = new MySqlCommand("SELECT tripdata.Sno, tripdata.EmpId,tripdata.VehicleNo FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (triproutes.RouteID = @dispid) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                cmd.Parameters.Add("@dispid", RouteID);
                cmd.Parameters.Add("@d1", GetLowDate(AssignDate));
                cmd.Parameters.Add("@d2", GetHighDate(AssignDate));
                DataTable dtcheck = vdm.SelectQuery(cmd).Tables[0];
                if (dtcheck.Rows.Count > 0)
                {
                    //foreach (DataRow drcheck in check.Rows)
                    //{
                    tripid = dtcheck.Rows[0]["Sno"].ToString();
                    context.Session["tripid"] = tripid;
                    empid = "";
                    empid = dtcheck.Rows[0]["EmpId"].ToString();
                    vehcleno = dtcheck.Rows[0]["VehicleNo"].ToString();
                    cmd = new MySqlCommand("SELECT productsdata.sno,productsdata.ProductName, tripsubdata.Qty AS TotalQty FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (tripdata.Sno = @tripid)");
                    cmd.Parameters.Add("@tripid", tripid);
                    DataTable dttripprdt = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drtripprdt in dttripprdt.Rows)
                    {
                        foreach (DataRow drprdtcpy in dtallProducts.Rows)
                        {
                            if (drtripprdt["sno"].ToString() == drprdtcpy["sno"].ToString())
                            {
                                float qty = 0;
                                float.TryParse(drtripprdt["TotalQty"].ToString(), out qty);
                                float qtycpy = 0;
                                float.TryParse(drprdtcpy["TotalQty"].ToString(), out qtycpy);
                                float totalqty = qty + qtycpy;
                                float invqty = 0;
                                if (drprdtcpy["Units"].ToString() == "ltr")
                                {
                                    float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                    drprdtcpy["Cans"] = totalqty / invqty;
                                }
                                if (drprdtcpy["Units"].ToString() == "kgs")
                                {
                                    float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                    drprdtcpy["Cans"] = totalqty / invqty;
                                }
                                if (drprdtcpy["Units"].ToString() == "ml")
                                {
                                    float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                    drprdtcpy["Tubs"] = totalqty / invqty;
                                }
                                if (drprdtcpy["Units"].ToString() == "gms")
                                {
                                    //float.TryParse(drprdt["Qty"].ToString(),out invqty);
                                }
                                drprdtcpy["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }
                    //}
                }
                else
                {
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", RouteID);
                    DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                    {
                        var routeid = drrouteitype["Route_id"].ToString();
                        var routeitype = drrouteitype["IndentType"].ToString();
                        DataTable dtProducts = new DataTable();
                        DataTable dtprdtcpy = new DataTable();
                        cmd = new MySqlCommand("SELECT branchroutes.RouteName, ROUND(SUM(indents_subtable.unitQty),2) AS TotalQty,indents.IndentType, productsdata.sno, productsdata.ProductName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (branchroutes.Sno = '" + routeid + "') and indents.Status<>@st and indents.IndentType=@itype and (indents.I_date BETWEEN @d1 AND @d2)  GROUP BY productsdata.ProductName ");
                        //cmd = new MySqlCommand("SELECT branchroutes.RouteName, SUM(indents_subtable.unitQty) AS TotalQty, productsdata.sno, productsdata.ProductName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno INNER JOIN indents ON branchdata.sno = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (branchroutes.Sno = '" + routeid + "') and indents.Status<>@st and indents.I_date BETWEEN @d1 AND @d2 GROUP BY productsdata.ProductName, productsdata.sno");
                        cmd.Parameters.Add("@st", "D");
                        cmd.Parameters.Add("@d1", GetLowDate(Currentdate));
                        cmd.Parameters.Add("@d2", GetHighDate(Currentdate));
                        cmd.Parameters.Add("@itype", routeitype);
                        //cmd.Parameters.Add("@dispatchid", int.Parse(word));
                        int.TryParse(context.Session["branch"].ToString(), out Sno);
                        dtProducts = vdm.SelectQuery(cmd).Tables[0];
                        foreach (DataRow drprdt in dtProducts.Rows)
                        {
                            foreach (DataRow drprdtcpy in dtallProducts.Rows)
                            {
                                if (drprdt["sno"].ToString() == drprdtcpy["sno"].ToString())
                                {
                                    float qty = 0;
                                    float.TryParse(drprdt["TotalQty"].ToString(), out qty);
                                    float qtycpy = 0;
                                    float.TryParse(drprdtcpy["TotalQty"].ToString(), out qtycpy);
                                    float totalqty = qty + qtycpy;
                                    float invqty = 0;
                                    if (drprdtcpy["Units"].ToString() == "ltr")
                                    {
                                        float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                        drprdtcpy["Cans"] = totalqty / invqty;
                                    }
                                    if (drprdtcpy["Units"].ToString() == "kgs")
                                    {
                                        float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                        drprdtcpy["Cans"] = totalqty / invqty;
                                    }
                                    if (drprdtcpy["Units"].ToString() == "ml")
                                    {
                                        float.TryParse(drprdtcpy["Qty"].ToString(), out invqty);
                                        drprdtcpy["Tubs"] = totalqty / invqty;
                                    }
                                    if (drprdtcpy["Units"].ToString() == "gms")
                                    {
                                        //float.TryParse(drprdt["Qty"].ToString(),out invqty);
                                    }
                                    drprdtcpy["TotalQty"] = totalqty;
                                }
                                else
                                {
                                }
                            }
                        }
                    }
                }
                int i = 1;
                foreach (DataRow dr in dtallProducts.Rows)
                {
                    if (DispatchStatus == "Load")
                    {
                        if (dr["TotalQty"].ToString() != "0")
                        {
                            int prdtsno = 0;
                            int.TryParse(dr["sno"].ToString(), out prdtsno);
                            float total_indt_qty = 0;
                            float.TryParse(dr["TotalQty"].ToString(), out total_indt_qty);
                            Products getProducts = new Products();
                            getProducts.snoO = i++.ToString();
                            getProducts.ProductName = dr["ProductName"].ToString();
                            getProducts.TotalQty = dr["TotalQty"].ToString();
                            getProducts.Productsno = dr["sno"].ToString();
                            getProducts.tubs = dr["Tubs"].ToString();
                            getProducts.cans = dr["Cans"].ToString();
                            getProducts.units = dr["Units"].ToString();
                            getProducts.qty = dr["Qty"].ToString();
                            getProducts.empid = empid;
                            getProducts.vehcleno = vehcleno;
                            Productslist.Add(getProducts);
                        }
                    }
                    else
                    {
                        int prdtsno = 0;
                        int.TryParse(dr["sno"].ToString(), out prdtsno);
                        float total_indt_qty = 0;
                        float.TryParse(dr["TotalQty"].ToString(), out total_indt_qty);
                        double extrltrs = 0;
                        double Qty = 0;
                        double.TryParse(dr["Qty"].ToString(), out Qty);
                        extrltrs = Math.Round((total_indt_qty % Qty), 0);
                        Products getProducts = new Products();
                        getProducts.snoO = i++.ToString();
                        getProducts.ProductName = dr["ProductName"].ToString();
                        getProducts.TotalQty = dr["TotalQty"].ToString();
                        getProducts.Productsno = dr["sno"].ToString();
                        getProducts.tubs = dr["Tubs"].ToString();
                        getProducts.cans = dr["Cans"].ToString();
                        getProducts.units = dr["Units"].ToString();
                        getProducts.qty = dr["Qty"].ToString();
                        getProducts.extrltrs = extrltrs.ToString();
                        getProducts.empid = empid;
                        getProducts.vehcleno = vehcleno;
                        Productslist.Add(getProducts);
                    }
                }
                var jsonSerializer = new JavaScriptSerializer();
                var jsonString = String.Empty;
                context.Request.InputStream.Position = 0;
                using (var inputStream = new StreamReader(context.Request.InputStream))
                {
                    jsonString = inputStream.ReadToEnd();
                }
                string response = GetJson(Productslist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Object reference not set to an instance of an object.")
                {
                    string msg = "Session Expired";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
                else
                {
                    string msg = ex.Message;
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
        }
        class inventorydetail
        {
            public string InventorySno { set; get; }
            public string Qty { set; get; }
            public string PrevInvQty { set; get; }
            public string Branchid { set; get; }
            public string Tripid { set; get; }
        }
        private void btnPlantTripSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                DateTime dtapril = new DateTime();
                DateTime dtmarch = new DateTime();
                int currentyear = ServerDateCurrentdate.Year;
                int nextyear = ServerDateCurrentdate.Year + 1;
                if (ServerDateCurrentdate.Month > 3)
                {
                    string apr = "4/1/" + currentyear;
                    dtapril = DateTime.Parse(apr);
                    string march = "3/31/" + nextyear;
                    dtmarch = DateTime.Parse(march);
                }
                if (ServerDateCurrentdate.Month <= 3)
                {
                    string apr = "4/1/" + (currentyear - 1);
                    dtapril = DateTime.Parse(apr);
                    string march = "3/31/" + (nextyear - 1);
                    dtmarch = DateTime.Parse(march);
                }
                DateTime ServerDate = ServerDateCurrentdate;
                string tripid = "";
                List<string> MsgList = new List<string>();
                if (context.Session["tripid"] == null)
                {
                }
                else
                {
                    tripid = context.Session["tripid"].ToString();
                }
                string Username = context.Session["userdata_sno"].ToString();
                string routelevel = context.Session["LevelType"].ToString();
                string dempid = context.Session["UserSno"].ToString();
                var title1 = context.Request.Params[1];
                Orders obj = js.Deserialize<Orders>(title1);
                string RouteID = obj.routename;
                string VehicleNo = obj.VehicleNo;
                string EmpID = "";
                EmpID = obj.EmpID;
                string BranchID = context.Session["branch"].ToString();
                string Branch_id = "";
                if (BranchID == "172" || BranchID == "3919")
                {
                    cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName, empmanage.EmpName, empmanage.Branch FROM dispatch INNER JOIN empmanage ON dispatch.BranchID = empmanage.Branch WHERE (dispatch.sno = @DespSno) AND (empmanage.LevelType = 'SODispatcher')");
                    cmd.Parameters.Add("@DespSno", RouteID);
                    DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                    if (dtemp.Rows.Count > 0)
                    {
                        EmpID = dtemp.Rows[0]["Sno"].ToString();
                        Branch_id = dtemp.Rows[0]["Branch"].ToString();
                    }
                }
                else
                {
                    cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName, empmanage.EmpName, empmanage.Branch FROM dispatch INNER JOIN empmanage ON dispatch.BranchID = empmanage.Branch WHERE (dispatch.sno = @DespSno) AND (empmanage.LevelType = 'SODispatcher')");
                    cmd.Parameters.Add("@DespSno", RouteID);
                    DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                    if (dtemp.Rows.Count > 0)
                    {
                        //EmpID = dtemp.Rows[0]["Sno"].ToString();
                        Branch_id = dtemp.Rows[0]["Branch"].ToString();
                    }
                }
                string IndentDate = context.Session["IndentDate"].ToString();
                DateTime Currentdate = Convert.ToDateTime(IndentDate);
                DateTime AssignDate = Currentdate;
                string dispdate = context.Session["DispatchDate"].ToString();
                if (dispdate == "0")
                {
                    Currentdate = Currentdate;
                }
                else
                {
                    Currentdate = Currentdate.AddDays(-1);
                }
                ServerDateCurrentdate = DateTime.Now;
                string operationtype = "";
                if (tripid == "")
                {
                    operationtype = "SAVE";
                }
                else
                {
                    operationtype = "EDIT";
                }
                if (operationtype == "SAVE")
                {
                    string DispType = context.Session["DispType"].ToString();
                    if (DispType == "SO")
                    {
                        cmd = new MySqlCommand("SELECT triproutes.RouteID, tripdata.Status, tripdata.Sno FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno WHERE (tripdata.Status = @Status) AND (triproutes.RouteID = @DispID) and (tripdata.EmpId=@EmpID) and (tripdata.Permissions<>'O')");
                        cmd.Parameters.Add("@Status", 'A');
                        cmd.Parameters.Add("@DispID", RouteID);
                        cmd.Parameters.Add("@EmpID", EmpID);
                        DataTable dtTrip = vdm.SelectQuery(cmd).Tables[0];
                        if (dtTrip.Rows.Count > 0)
                        {
                            cmd = new MySqlCommand("update tripdata set Status=@status where  Sno=@TripID");
                            cmd.Parameters.Add("@status", 'P');
                            cmd.Parameters.Add("@TripID", dtTrip.Rows[0]["Sno"].ToString());
                            vdm.Update(cmd);
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("update tripdata set Status=@status where Status=@st and EmpId='" + EmpID + "'");
                        cmd.Parameters.Add("@st", 'A');
                        cmd.Parameters.Add("@status", 'P');
                        vdm.Update(cmd);
                    }
                    string fromstate = context.Session["stateid"].ToString();
                    string tostate = "";
                    string branchid = "";
                    string companycode = "";
                    string statecode = "";
                    cmd = new MySqlCommand("SELECT branchdata.companycode, branchdata.sno, branchdata.stateid, statemastar.gststatecode FROM branchdata INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (branchdata.sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", Branch_id);
                    DataTable dtEmpID = vdm.SelectQuery(cmd).Tables[0];
                    if (dtEmpID.Rows.Count > 0)
                    {
                        tostate = dtEmpID.Rows[0]["stateid"].ToString();
                        branchid = dtEmpID.Rows[0]["sno"].ToString();
                        companycode = dtEmpID.Rows[0]["companycode"].ToString();
                        statecode = dtEmpID.Rows[0]["gststatecode"].ToString();
                    }
                    string TripDCNo = "";
                    if (fromstate == tostate)
                    {
                        //if (ServerDateCurrentdate.ToString("dd/MM/yyyy") == Currentdate.ToString("dd/MM/yyyy"))
                        //{
                        cmd = new MySqlCommand("SELECT IFNULL(MAX(agentstno), 0) + 1 AS Sno FROM agentst WHERE (soid = @soid) AND (IndDate BETWEEN @d1 AND @d2)");
                        cmd.Parameters.Add("@soid", context.Session["branch"].ToString());
                        cmd.Parameters.Add("@d1", GetLowDate(dtapril));
                        cmd.Parameters.Add("@d2", GetHighDate(dtmarch));
                        DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                        TripDCNo = dtadcno.Rows[0]["Sno"].ToString();
                        cmd = new MySqlCommand("Insert Into agentst (BranchId,soid,IndDate,agentstno,stateid,companycode,moduleid,doe) Values(@BranchId,@soid,@IndDate,@agentstno,@stateid,@companycode,@moduleid,@doe)");
                        cmd.Parameters.Add("@BranchId", branchid);
                        cmd.Parameters.Add("@soid", context.Session["branch"].ToString());
                        cmd.Parameters.Add("@IndDate", Currentdate);
                        cmd.Parameters.Add("@agentstno", TripDCNo);
                        cmd.Parameters.Add("@stateid", statecode);
                        cmd.Parameters.Add("@companycode", companycode);
                        cmd.Parameters.Add("@moduleid", context.Session["moduleid"].ToString());
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                        //}
                    }
                    else
                    {
                        //if (ServerDateCurrentdate.ToString("dd/MM/yyyy") == Currentdate.ToString("dd/MM/yyyy"))
                        //{
                        cmd = new MySqlCommand("SELECT IFNULL(MAX(agentdcno), 0) + 1 AS Sno FROM agentdc WHERE (soid = @soid) AND (IndDate BETWEEN @d1 AND @d2)");
                        cmd.Parameters.Add("@soid", context.Session["branch"].ToString());
                        cmd.Parameters.Add("@d1", GetLowDate(dtapril));
                        cmd.Parameters.Add("@d2", GetHighDate(dtmarch));
                        DataTable dtadcno = vdm.SelectQuery(cmd).Tables[0];
                        TripDCNo = dtadcno.Rows[0]["Sno"].ToString();
                        cmd = new MySqlCommand("Insert Into Agentdc (BranchId,soid,IndDate,agentdcno,stateid,companycode,moduleid,doe) Values(@BranchId,@soid,@IndDate,@agentdcno,@stateid,@companycode,@moduleid,@doe)");
                        cmd.Parameters.Add("@BranchId", branchid);
                        cmd.Parameters.Add("@soid", context.Session["branch"].ToString());
                        cmd.Parameters.Add("@IndDate", Currentdate);
                        cmd.Parameters.Add("@agentdcno", TripDCNo);
                        cmd.Parameters.Add("@stateid", statecode);
                        cmd.Parameters.Add("@companycode", companycode);
                        cmd.Parameters.Add("@moduleid", context.Session["moduleid"].ToString());
                        cmd.Parameters.Add("@doe", ServerDateCurrentdate);
                        vdm.insert(cmd);
                        //}
                    }
                    cmd = new MySqlCommand("insert into tripdata (EmpId,AssignDate,Status,Userdata_sno,Permissions,VehicleNo,I_Date,DEmpId,GPStatus,PlanStatus,Plantime,BranchID,DCNO,DC_Type)values(@EmpId,@AssignDate,@status,@Userdata_sno,@Permissions,@VehicleNo,@indendate,@dempid,@gpstatus,@PlanStatus,@Plantime,@BranchID,@DCNO,@DC_Type)");
                    cmd.Parameters.Add("@Permissions", obj.Permissions);
                    cmd.Parameters.Add("@EmpId", EmpID);
                    cmd.Parameters.Add("@AssignDate", AssignDate);
                    cmd.Parameters.Add("@indendate", Currentdate);
                    cmd.Parameters.Add("@dempid", dempid);
                    cmd.Parameters.Add("@status", "A");
                    cmd.Parameters.Add("@gpstatus", "A");
                    cmd.Parameters.Add("@VehicleNo", VehicleNo);
                    cmd.Parameters.Add("@Userdata_sno", Username);
                    cmd.Parameters.Add("@PlanStatus", "Planned");
                    cmd.Parameters.Add("@Plantime", ServerDateCurrentdate);
                    cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                    cmd.Parameters.Add("@DCNO", TripDCNo);
                    if (fromstate == tostate)
                    {
                        cmd.Parameters.Add("@DC_Type", "1");
                    }
                    else
                    {
                        cmd.Parameters.Add("@DC_Type", "0");
                    }
                    long Tripdata_Sno = vdm.insertScalar(cmd);
                    context.Session["TripIDSno"] = Tripdata_Sno;
                    cmd = new MySqlCommand("insert into triproutes(Tripdata_sno,RouteID)values(@tripdata_sno,@routeid)");
                    cmd.Parameters.Add("@tripdata_sno", Tripdata_Sno);
                    cmd.Parameters.Add("@routeid", RouteID);
                    vdm.insert(cmd);
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            if (o.Qty != "0")
                            {
                                cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@deliverqty)");
                                cmd.Parameters.Add("@Tripdata_Sno", Tripdata_Sno);
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                float qty;
                                float.TryParse(o.Qty, out qty);
                                //float manuftreming_qty = 0;
                                //float.TryParse(o.RemainingQty, out manuftreming_qty);
                                cmd.Parameters.Add("@Qty", qty);
                                float delqty = 0;
                                cmd.Parameters.Add("@deliverqty", delqty);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    foreach (inventorydetail iv in obj.invdata)
                    {
                        if (iv.InventorySno != null)
                        {
                            if (iv.Qty != "")
                            {
                                cmd = new MySqlCommand("insert into tripinvdata (Tripdata_Sno,invid,Qty,Remaining)values(@Tripdata_Sno,@invId,@Qty,@remaining)");
                                cmd.Parameters.Add("@Tripdata_Sno", Tripdata_Sno);
                                cmd.Parameters.Add("@invId", iv.InventorySno);
                                float qty;
                                float.TryParse(iv.Qty, out qty);
                                cmd.Parameters.Add("@Qty", qty);
                                cmd.Parameters.Add("@remaining", qty);
                                if (qty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Saved";
                    MsgList.Add(msg);
                    string response = GetJson(MsgList);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("update tripdata set EmpId=@EmpId,AssignDate=@AssignDate,DespatchStatus=@DespatchStatus,DispTime=@DispTime,Status=@status,Userdata_sno=@Userdata_sno,Permissions=@Permissions,VehicleNo=@VehicleNo,I_Date=@indendate,DEmpId=@dempid where Sno=@tripid");
                    cmd.Parameters.Add("@tripid", tripid);
                    cmd.Parameters.Add("@Permissions", obj.Permissions);
                    cmd.Parameters.Add("@DespatchStatus", "Yes");
                    cmd.Parameters.Add("@EmpId", EmpID);
                    cmd.Parameters.Add("@AssignDate", AssignDate);
                    cmd.Parameters.Add("@indendate", Currentdate);
                    cmd.Parameters.Add("@dempid", dempid);
                    cmd.Parameters.Add("@status", "A");
                    cmd.Parameters.Add("@VehicleNo", VehicleNo);
                    cmd.Parameters.Add("@Userdata_sno", Username);
                    cmd.Parameters.Add("@DispTime", ServerDateCurrentdate);
                    vdm.Update(cmd);
                    context.Session["TripIDSno"] = tripid;
                    cmd = new MySqlCommand("update triproutes set RouteID=@routeid where Tripdata_sno=@tripid");
                    cmd.Parameters.Add("@tripid", tripid);
                    cmd.Parameters.Add("@routeid", RouteID);
                    if (vdm.Update(cmd) == 0)
                    {
                        cmd = new MySqlCommand("insert into triproutes(Tripdata_sno,RouteID)values(@tripdata_sno,@routeid) ");
                        cmd.Parameters.Add("@tripdata_sno", tripid);
                        cmd.Parameters.Add("@routeid", RouteID);
                        vdm.insert(cmd);
                    }
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            if (o.Qty != "0")
                            {
                                cmd = new MySqlCommand("update tripsubdata set Tripdata_Sno=@Tripdata_Sno,ProductId=@ProductId,Qty=@Qty,DeliverQty=@deliverqty where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                cmd.Parameters.Add("@Tripdata_Sno", tripid);
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                float qty;
                                float.TryParse(o.Qty, out qty);
                                //float manuftreming_qty = 0;
                                //float.TryParse(o.RemainingQty, out manuftreming_qty);
                                cmd.Parameters.Add("@Qty", qty);
                                float delqty = 0;
                                cmd.Parameters.Add("@deliverqty", delqty);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("insert into tripsubdata (Tripdata_Sno,ProductId,Qty,DeliverQty)values(@Tripdata_Sno,@ProductId,@Qty,@deliverqty)");
                                    cmd.Parameters.Add("@Tripdata_Sno", tripid);
                                    cmd.Parameters.Add("@ProductId", o.Productsno);
                                    cmd.Parameters.Add("@Qty", qty);
                                    cmd.Parameters.Add("@deliverqty", delqty);
                                    vdm.insert(cmd);
                                }
                            }
                            else
                            {
                                cmd = new MySqlCommand("DELETE FROM tripsubdata where Tripdata_Sno=@Tripdata_Sno and ProductId=@ProductId");
                                cmd.Parameters.Add("@Tripdata_Sno", tripid);
                                cmd.Parameters.Add("@ProductId", o.Productsno);
                                vdm.Delete(cmd);
                            }
                        }
                    }
                    foreach (inventorydetail iv in obj.invdata)
                    {
                        if (iv.InventorySno != null)
                        {
                            if (iv.Qty != "")
                            {
                                cmd = new MySqlCommand("update tripinvdata set Tripdata_Sno=@Tripdata_Sno,invid=@invId,Qty=@Qty,Remaining=@remaining where Tripdata_Sno=@Tripdata_Sno and invid=@invId");
                                cmd.Parameters.Add("@Tripdata_Sno", tripid);
                                cmd.Parameters.Add("@invId", iv.InventorySno);
                                float qty;
                                float.TryParse(iv.Qty, out qty);
                                cmd.Parameters.Add("@Qty", qty);
                                cmd.Parameters.Add("@remaining", qty);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("insert into tripinvdata (Tripdata_Sno,invid,Qty,Remaining)values(@Tripdata_Sno,@invId,@Qty,@remaining)");
                                    cmd.Parameters.Add("@Tripdata_Sno", tripid);
                                    cmd.Parameters.Add("@invId", iv.InventorySno);
                                    cmd.Parameters.Add("@Qty", qty);
                                    cmd.Parameters.Add("@remaining", qty);
                                    if (qty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                                cmd = new MySqlCommand("Update inventory_monitor Set Qty=Qty-@Qty where BranchId=@BranchId and Inv_Sno=@Inv_Sno");
                                cmd.Parameters.Add("@Inv_Sno", iv.InventorySno);
                                cmd.Parameters.Add("@Qty", qty);
                                cmd.Parameters.Add("@BranchId", context.Session["branch"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into inventory_monitor(Qty,Inv_Sno,BranchId) values(@Qty,@Inv_Sno,@BranchId)");
                                    cmd.Parameters.Add("@Qty", qty);
                                    cmd.Parameters.Add("@Inv_Sno", iv.InventorySno);
                                    cmd.Parameters.Add("@BranchId", context.Session["branch"].ToString());
                                    vdm.insert(cmd);
                                }
                                cmd = new MySqlCommand("update invtransactions12 set Qty=@Qty,DOE=@DOE where FromTran=@From and B_Inv_Sno=@B_Inv_Sno and EmpID=@EmpID and ToTran=@To and TransType=@TransType");
                                cmd.Parameters.Add("@B_Inv_Sno", iv.InventorySno);
                                cmd.Parameters.Add("@Qty", qty);
                                cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                cmd.Parameters.Add("@From", context.Session["branch"].ToString());
                                cmd.Parameters.Add("@TransType", "3");
                                cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                cmd.Parameters.Add("@To", tripid);
                                if (vdm.Update(cmd) == 0)
                                {
                                    cmd = new MySqlCommand("Insert into  invtransactions12(B_Inv_Sno,Qty,DOE,EmpID,FromTran,ToTran,TransType) values(@B_Inv_Sno,@Qty,@DOE,@EmpID,@From,@To,@TransType)");
                                    cmd.Parameters.Add("@B_Inv_Sno", iv.InventorySno);
                                    cmd.Parameters.Add("@Qty", qty);
                                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                                    cmd.Parameters.Add("@From", context.Session["branch"].ToString());
                                    cmd.Parameters.Add("@TransType", "3");
                                    cmd.Parameters.Add("@EmpID", context.Session["UserSno"].ToString());
                                    cmd.Parameters.Add("@To", tripid);
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    #region sms

                    cmd = new MySqlCommand("SELECT Sno, smsstatus, Status, AssignDate, EmpId, I_Date FROM tripdata WHERE (Sno = @tripid)");
                    cmd.Parameters.Add("@tripid", tripid);
                    DataTable dt_smsstatus = vdm.SelectQuery(cmd).Tables[0];
                    string sms_status = "0";
                    if (dt_smsstatus.Rows.Count > 0)
                    {
                        sms_status = dt_smsstatus.Rows[0]["smsstatus"].ToString();
                    }
                    if (sms_status == "0")
                    {
                        string ProductName = "";
                        string DetailProductName = "";
                        string Producttot = "";
                        string dispatchtime = "";
                        double TotalQty = 0;
                        cmd = new MySqlCommand("SELECT result.Sno, result.AssignDate, result.Plantime, result.DispTime, dispatch.DispName FROM (SELECT Sno, AssignDate, Plantime, DispTime FROM tripdata WHERE (BranchID = @branchid) AND (AssignDate BETWEEN @d1 AND @d2) AND (DispTime IS NOT NULL)) result INNER JOIN triproutes ON result.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (dispatch.flag <> 0) AND (dispatch.Branch_Id = @branchid) ORDER BY result.DispTime");
                        cmd.Parameters.Add("@branchid", context.Session["branch"].ToString());
                        cmd.Parameters.Add("@d1", GetLowDate(AssignDate));
                        cmd.Parameters.Add("@d2", GetHighDate(AssignDate));
                        DataTable dtdispatchno = vdm.SelectQuery(cmd).Tables[0];
                        if (dtdispatchno.Rows.Count > 0)
                        {
                            cmd = new MySqlCommand("SELECT DispTime FROM tripdata WHERE (Sno = @tripid)");
                            cmd.Parameters.Add("@tripid", tripid);
                            DataTable dtdisptime = vdm.SelectQuery(cmd).Tables[0];
                            DateTime IndTime = ServerDateCurrentdate;
                            if (dtdisptime.Rows.Count > 0)
                            {
                                dispatchtime = dtdisptime.Rows[0]["DispTime"].ToString();
                                IndTime = Convert.ToDateTime(dtdisptime.Rows[0]["DispTime"].ToString());
                            }
                            string brch = "";
                            if (context.Session["branch"].ToString() == "172")
                            {
                                brch = "PBK__";
                            }
                            if (context.Session["branch"].ToString() == "158")
                            {
                                brch = "WYRA__";
                            }
                            if (context.Session["branch"].ToString() == "1801")
                            {
                                brch = "KPM__";
                            }
                            ProductName += brch + "Despatch-" + dtdispatchno.Rows.Count + "\r\n";
                            ProductName += "Date :" + AssignDate.ToString("dd-MM") + "   Time:" + IndTime.ToString("HH:mm") + "\r\n";
                        }
                        cmd = new MySqlCommand("SELECT sno, SubCat_sno, ProductName, Qty, Units, UnitPrice, Flag, UserData_sno, Rank, Inventorysno, VatPercent, Product_type FROM productsdata");
                        DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                if (o.Qty != "0")
                                {
                                    double unitQty = 0;
                                    double.TryParse(o.Qty, out unitQty);
                                    DataRow[] drproducts = dtProducts.Select("sno=" + o.Productsno + "");
                                    string product = "";
                                    foreach (DataRow drp in drproducts)
                                    {
                                        product = drp["ProductName"].ToString();
                                    }
                                    DetailProductName += product + "->" + Math.Round(unitQty, 2) + ";" + "\r\n";
                                    TotalQty += Math.Round(unitQty, 2);
                                }
                            }
                        }
                        // cmd = new MySqlCommand("SELECT dispatch.sno, dispatch.BranchID, SUM(tripsubdata.Qty) AS dispatchqty, products_category.Categoryname, products_category.sno AS categorysno,dispatch.DispName, productsdata.ProductName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN (SELECT Sno, AssignDate FROM tripdata WHERE (AssignDate BETWEEN @d1 AND @d2)) tripdat ON triproutes.Tripdata_sno = tripdat.Sno INNER JOIN tripsubdata ON tripdat.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (dispatch.DispMode IS NULL) AND (dispatch.sno = @dispid) OR (dispatch.DispMode = 'SPL') AND (dispatch.sno = @dispid) GROUP BY productsdata.sno ORDER BY categorysno");
                        cmd = new MySqlCommand("SELECT dispatch.sno, dispatch.BranchID, SUM(tripsubdata.Qty) AS dispatchqty, products_category.Categoryname, products_category.sno AS categorysno, dispatch.DispName, productsdata.ProductName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN (SELECT Sno, AssignDate FROM tripdata WHERE (AssignDate BETWEEN @d1 AND @d2)) tripdat ON triproutes.Tripdata_sno = tripdat.Sno INNER JOIN tripsubdata ON tripdat.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (dispatch.DispMode IS NULL) AND (dispatch.sno = @dispid) OR (dispatch.DispMode = 'SPL') AND (dispatch.sno = @dispid) GROUP BY categorysno");
                        cmd.Parameters.Add("@dispid", RouteID);
                        cmd.Parameters.Add("@d1", GetLowDate(AssignDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", GetHighDate(AssignDate.AddDays(-1)));
                        DataTable dtpreviousdispatch = vdm.SelectQuery(cmd).Tables[0];
                        cmd = new MySqlCommand("SELECT dispatch.sno, dispatch.BranchID, SUM(tripsubdata.Qty) AS dispatchqty, products_category.Categoryname, products_category.sno AS categorysno, dispatch.DispName FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN (SELECT Sno, AssignDate FROM tripdata WHERE (Sno = @tripid)) tripdat ON triproutes.Tripdata_sno = tripdat.Sno INNER JOIN tripsubdata ON tripdat.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (dispatch.DispMode IS NULL) OR (dispatch.DispMode = 'SPL') GROUP BY categorysno");
                        cmd.Parameters.Add("@tripid", tripid);
                        DataTable dtmilkandcurd = vdm.SelectQuery(cmd).Tables[0];
                        cmd = new MySqlCommand("SELECT SUM(tripsubdata.Qty) AS dispatchqty, products_category.Categoryname, products_category.sno AS categorysno, dispatch.DispName, productsdata.sno, productsdata.ProductName FROM  dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN (SELECT Sno, AssignDate FROM tripdata WHERE (Sno = @tripid)) tripdat ON triproutes.Tripdata_sno = tripdat.Sno INNER JOIN tripsubdata ON tripdat.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (dispatch.DispMode IS NULL) AND (products_category.sno > 10) OR (dispatch.DispMode = 'SPL') GROUP BY productsdata.sno");
                        cmd.Parameters.Add("@tripid", tripid);
                        DataTable dtbiprdt = vdm.SelectQuery(cmd).Tables[0];
                        double milk = 0;
                        double Prevmilk = 0;
                        double curd = 0;
                        double Prevcurd = 0;
                        double BM = 0;
                        double PrevBM = 0;
                        double other = 0;
                        double prevother = 0;
                        double totmilk = 0;
                        double totcurd = 0;
                        double totBM = 0;
                        double tot = 0;
                        double Prevtot = 0;
                        double diffmilk = 0;
                        double diffcurd = 0;
                        double diffBM = 0;
                        double finaldiff = 0;
                        if (dtmilkandcurd.Rows.Count > 0)
                        {

                            foreach (DataRow dr in dtmilkandcurd.Rows)
                            {

                                if (dr["categorysno"].ToString() == "9")
                                {

                                    double.TryParse(dr["dispatchqty"].ToString(), out milk);
                                    milk = Math.Round(milk, 2);
                                    totmilk += milk;
                                    tot += milk;

                                    foreach (DataRow drdtclubtotal in dtpreviousdispatch.Select("categorysno='" + dr["categorysno"].ToString() + "'"))
                                    {
                                        double.TryParse(drdtclubtotal["dispatchqty"].ToString(), out Prevmilk);
                                    }
                                    diffmilk = Math.Round(milk - Prevmilk, 2);
                                    Prevtot += Prevmilk;

                                    Producttot += "MILK :" + milk + "(" + Math.Round(diffmilk, 2) + ")" + "\r\n";
                                }
                                else if (dr["categorysno"].ToString() == "10")
                                {
                                    double.TryParse(dr["dispatchqty"].ToString(), out curd);
                                    curd = Math.Round(curd, 2);
                                    totcurd += curd;
                                    tot += curd;

                                    foreach (DataRow drdtclubtotal in dtpreviousdispatch.Select("categorysno='" + dr["categorysno"].ToString() + "'"))
                                    {
                                        double.TryParse(drdtclubtotal["dispatchqty"].ToString(), out Prevcurd);
                                    }
                                    diffcurd = Math.Round(curd - Prevcurd, 2);
                                    Prevtot += Prevcurd;

                                    Producttot += "Curd :" + curd + "(" + Math.Round(diffcurd, 2) + ")" + "\r\n";
                                }
                                else if (dr["categorysno"].ToString() == "12")
                                {
                                    double.TryParse(dr["dispatchqty"].ToString(), out BM);
                                    BM = Math.Round(BM, 2);
                                    totBM += BM;
                                    tot += BM;
                                    foreach (DataRow drdtclubtotal in dtpreviousdispatch.Select("categorysno='" + dr["categorysno"].ToString() + "'"))
                                    {
                                        double.TryParse(drdtclubtotal["dispatchqty"].ToString(), out PrevBM);
                                    }
                                    diffBM = Math.Round(BM - PrevBM, 2);
                                    Prevtot += PrevBM;

                                    Producttot += "Butter Milk :" + BM + "(" + Math.Round(diffBM, 2) + ")" + "\r\n";
                                }
                                else
                                {
                                    // double.TryParse(dr["dispatchqty"].ToString(), out other);

                                    foreach (DataRow drdtclubtotal in dtbiprdt.Select("categorysno='" + dr["categorysno"].ToString() + "'"))
                                    {

                                        double.TryParse(drdtclubtotal["dispatchqty"].ToString(), out other);
                                        other = Math.Round(other, 2);
                                        tot += other;
                                        Producttot += drdtclubtotal["ProductName"].ToString() + "  :" + other + "\r\n";

                                    }
                                }
                            }
                            foreach (DataRow drdt in dtpreviousdispatch.Rows)
                            {
                                if (drdt["categorysno"].ToString() == "9")
                                {
                                }
                                else if (drdt["categorysno"].ToString() == "10")
                                {
                                }
                                else if (drdt["categorysno"].ToString() == "12")
                                {
                                }
                                else
                                {
                                    double.TryParse(drdt["dispatchqty"].ToString(), out prevother);
                                    prevother = Math.Round(prevother, 2);
                                    Prevtot += prevother;
                                    //ProductName += dr["ProductName"].ToString() + "  :" + other + "\r\n";
                                }

                            }
                        }
                        finaldiff = Math.Round(tot - Prevtot, 2);
                        Producttot += "Total :" + tot + "(" + Math.Round(finaldiff, 2) + ")" + "\r\n";
                        cmd = new MySqlCommand("SELECT mobilenotable.PhoneNumber, dispatch.DispName,dispatch.DispTime FROM mobilenotable INNER JOIN dispatch ON mobilenotable.DispNo = dispatch.sno WHERE (mobilenotable.DispNo = @DispNo) and (mobilenotable.MsgType = @Msgtype) ");
                        cmd.Parameters.Add("@DispNo", RouteID);
                        cmd.Parameters.Add("@Msgtype", 2);
                        DataTable dtPhoneNumbers = vdm.SelectQuery(cmd).Tables[0];
                        int msgcount = 0;
                        if (dtPhoneNumbers.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtPhoneNumbers.Rows)
                            {
                                string phonenumber = dr["PhoneNumber"].ToString();
                                string time = "";
                                if (dr["DispTime"].ToString() == "")
                                {
                                    DateTime distime = Convert.ToDateTime(dispatchtime);
                                    time = distime.ToString("HH:mm");
                                }
                                else
                                {
                                    DateTime distime = Convert.ToDateTime(dr["DispTime"].ToString());
                                    time = distime.ToString("HH:mm");
                                }

                                string DispatchName = dr["DispName"].ToString();
                                string[] words = DispatchName.Split('_');
                                string dttime = ServerDate.ToString("dd/MM/yyyy");
                                if (msgcount == 0)
                                {
                                    ProductName += words[0] + "(" + time + ")" + "\r\n";
                                    ProductName += "DC NO :" + tripid + "\r\n";
                                    ProductName += Producttot;
                                    msgcount++;
                                }
                                if (phonenumber.Length == 10)
                                {
                                    try
                                    {
                                        WebClient client = new WebClient();
                                        string baseurl = "http://103.16.101.52:8080/sendsms/bulksms?username=kapd-vyshnavi&password=vysavi&type=0&dlr=1&destination=" + phonenumber + "&source=VYSNAVI&message=%20" + ProductName + "";
                                        Stream data = client.OpenRead(baseurl);
                                        StreamReader reader = new StreamReader(data);
                                        string ResponseID = reader.ReadToEnd();
                                        data.Close();
                                        reader.Close();
                                    }
                                    catch
                                    {
                                    }
                                }
                                if (phonenumber != "9382525919")
                                {
                                    if (phonenumber.Length == 10)
                                    {
                                        try
                                        {
                                            WebClient client = new WebClient();
                                            string baseurl = "http://103.16.101.52:8080/sendsms/bulksms?username=kapd-vyshnavi&password=vysavi&type=0&dlr=1&destination=" + phonenumber + "&source=VYSNAVI&message=%20" + words[0] + "%20Despatch%20%20Completed%20%20for%20:" + dttime + "%20With\r\n" + "DCNo:" + tripid + "\r\n" + DetailProductName + "TotalQty ->" + TotalQty + "";
                                            Stream data = client.OpenRead(baseurl);
                                            StreamReader reader = new StreamReader(data);
                                            string ResponseID = reader.ReadToEnd();
                                            data.Close();
                                            reader.Close();
                                        }
                                        catch
                                        {
                                        }
                                    }
                                }
                            }
                        }
                        int smsstat = 1;
                        cmd = new MySqlCommand("update tripdata set smsstatus=@sms_status where Sno=@tripid");
                        cmd.Parameters.Add("@tripid", tripid);
                        cmd.Parameters.Add("@sms_status", smsstat);
                        vdm.Update(cmd);
                    }
                    #endregion
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Updated";
                    MsgList.Add(msg);
                    string response = GetJson(MsgList);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void Gettripinventory_manage(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dt = new DataTable();
                DataTable dtallinv = new DataTable();
                DataTable dtassigned_inv = new DataTable();
                DateTime todaydt = DateTime.Now;
                string username = context.Request["username"];
                //string trpid=context.Session["tripid"].ToString();
                if (context.Session["tripid"] != null)
                {
                    cmd = new MySqlCommand("SELECT tripinvdata.Qty, invmaster.InvName, invmaster.sno FROM tripdata INNER JOIN tripinvdata ON tripdata.Sno = tripinvdata.Tripdata_sno INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripdata.Sno = @tripid) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                    cmd.Parameters.Add("@tripid", context.Session["tripid"].ToString());
                    cmd.Parameters.Add("@d1", GetLowDate(todaydt));
                    cmd.Parameters.Add("@d2", GetHighDate(todaydt));
                    dt = vdm.SelectQuery(cmd).Tables[0];

                    cmd = new MySqlCommand("select InvName,flag,sno From invmaster Where Userdata_sno= @username");
                    cmd.Parameters.Add("@username", context.Session["userdata_sno"].ToString());
                    dtassigned_inv = vdm.SelectQuery(cmd).Tables[0];
                    dtallinv = new DataTable();
                    dtallinv.Columns.Add("sno");
                    dtallinv.Columns.Add("InvName");
                    dtallinv.Columns.Add("TotalQty");
                    foreach (DataRow dr in dtassigned_inv.Rows)
                    {
                        DataRow newRow = dtallinv.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["InvName"] = dr["InvName"].ToString();
                        newRow["TotalQty"] = "0";
                        dtallinv.Rows.Add(newRow);
                    }
                    foreach (DataRow drinv in dt.Rows)
                    {
                        foreach (DataRow drallinv in dtallinv.Rows)
                        {
                            if (drinv["sno"].ToString() == drallinv["sno"].ToString())
                            {
                                float qtycpy = 0;
                                float.TryParse(drinv["Qty"].ToString(), out qtycpy);
                                float totalqty = qtycpy;
                                drallinv["TotalQty"] = totalqty;
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    cmd = new MySqlCommand("select InvName,flag,sno From invmaster Where Userdata_sno= @username");
                    cmd.Parameters.Add("@username", context.Session["userdata_sno"].ToString());
                    dt = vdm.SelectQuery(cmd).Tables[0];
                    dtallinv = new DataTable();
                    dtallinv.Columns.Add("sno");
                    dtallinv.Columns.Add("InvName");
                    dtallinv.Columns.Add("TotalQty");
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow newRow = dtallinv.NewRow();
                        newRow["sno"] = dr["sno"].ToString();
                        newRow["InvName"] = dr["InvName"].ToString();
                        newRow["TotalQty"] = "0";
                        dtallinv.Rows.Add(newRow);
                    }
                    foreach (DataRow drinv in dt.Rows)
                    {
                        foreach (DataRow drallinv in dtallinv.Rows)
                        {
                            if (drinv["sno"].ToString() == drallinv["sno"].ToString())
                            {
                                float qtycpy = 0;
                                float.TryParse(drallinv["TotalQty"].ToString(), out qtycpy);
                                float totalqty = qtycpy;
                                drallinv["TotalQty"] = totalqty;
                            }
                            else
                            {
                            }
                        }
                    }

                }
                List<inventorymng> inventorylist = new List<inventorymng>();
                int i = 1;
                if (context.Session["get_orderedprdtsnames"] != "")
                {
                    foreach (DataRow dr in dtallinv.Rows)
                    {
                        inventorymng Getinventorymng = new inventorymng();
                        Getinventorymng.snoO = i++.ToString();
                        Getinventorymng.inventoryname = dr["InvName"].ToString();
                        //Getinventorymng.flag = dr["flag"].ToString();
                        Getinventorymng.sno = dr["sno"].ToString();
                        Getinventorymng.totqty = dr["TotalQty"].ToString();
                        inventorylist.Add(Getinventorymng);
                    }
                }
                else
                {
                }
                string response = GetJson(inventorylist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        public class inventorymng
        {
            public string snoO { get; set; }
            public string sno { get; set; }
            public string inventoryname { get; set; }
            public string totqty { get; set; }
            public string purchasedate { get; set; }
            public string qty { get; set; }
            public string Qty { get; set; }
            public string cost { get; set; }
            public string total { get; set; }
            public string flag { get; set; }
            public string brnchname { get; set; }
            public string employeename { get; set; }
            public string prdtname { get; set; }
            public string mtrgt { get; set; }
            public string wtrgt { get; set; }
            public string dtrgt { get; set; }
            public string brnchhidden { get; set; }
            public string category_sno { get; set; }
            public string SubCat_sno { get; set; }
            public string employeesno { get; set; }
            public string tripid { get; set; }
        }
        private void GetVehicleNos(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("Select VehicleNo,Capacity from VehicleMaster where BranchID=@BranchID");
                cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                DataTable dtVehicle = vdm.SelectQuery(cmd).Tables[0];
                List<VehicleClass> Vehiclelist = new List<VehicleClass>();
                foreach (DataRow dr in dtVehicle.Rows)
                {
                    VehicleClass getVehicles = new VehicleClass();
                    getVehicles.VehicleNo = dr["VehicleNo"].ToString();
                    getVehicles.Capacity = dr["Capacity"].ToString();
                    Vehiclelist.Add(getVehicles);
                }
                string response = GetJson(Vehiclelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class VehicleClass
        {
            public string VehicleNo { get; set; }
            public string Capacity { get; set; }
        }
        class PlantEmployee
        {
            public string Employee_id { set; get; }
            public string EmployeeName { set; get; }
        }
        private void GetDispatchValues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string DispSno = context.Request["despatchsno"];
                string IndentDate = context.Request["IndentDate"];
                DateTime dtIndentDate = Convert.ToDateTime(IndentDate);
                //string DispatchStatus = context.Request["DispatchStatus"];
                cmd = new MySqlCommand("SELECT DispName, DispType, BranchID, Dispdate, sno FROM  dispatch WHERE (sno = @DispSno) GROUP BY DispName");
                cmd.Parameters.Add("@DispSno", DispSno);
                DataTable dtDispatch = vdm.SelectQuery(cmd).Tables[0];
                context.Session["DispName"] = dtDispatch.Rows[0]["DispName"].ToString();
                context.Session["DispType"] = dtDispatch.Rows[0]["DispType"].ToString();
                context.Session["DispSno"] = DispSno;
                //context.Session["DispatchStatus"] = DispatchStatus;
                string branchid = dtDispatch.Rows[0]["BranchID"].ToString();
                context.Session["SOBranchId"] = dtDispatch.Rows[0]["BranchID"].ToString();
                context.Session["DispatchDate"] = dtDispatch.Rows[0]["Dispdate"].ToString();
                context.Session["VehicleNo"] = "";
                context.Session["IndentDate"] = dtIndentDate.ToString();
                string Msg = "Success";
                string errresponse = GetJson(Msg);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        private void Get_Employee(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Username = context.Session["userdata_sno"].ToString();
                List<PlantEmployee> Employeelist = new List<PlantEmployee>();
                string leveltype = context.Session["LevelType"].ToString();
                if (leveltype == "Admin" || leveltype == "MAdmin" || leveltype == "PlantDispatcher")
                {

                    string DispType = context.Session["DispType"].ToString();
                    if (DispType == "SO")
                    {
                        //cmd = new MySqlCommand(" SELECT Sno, EmpName FROM empmanage WHERE (LevelType = 'SODispatcher')");
                        cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.EmpName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SubBranch WHERE (empmanage.LevelType = 'SODispatcher') AND (branchmappingtable.SuperBranch = @Branch) ");
                        cmd.Parameters.Add("@Branch", context.Session["branch"].ToString());

                    }
                    else
                    {
                        cmd = new MySqlCommand("select Sno,EmpName from empmanage where LevelType REGEXP 'Opperations|Dispatcher' and Userdata_sno=@UserName and Branch=@Branch ");
                        cmd.Parameters.Add("@UserName", Username);
                        cmd.Parameters.Add("@Branch", context.Session["branch"].ToString());
                    }
                }
                if (leveltype == "MAdmin")
                {
                    cmd = new MySqlCommand("select Sno,EmpName from empmanage where Userdata_sno=@UserName and LevelType<>'Admin'");
                    cmd.Parameters.Add("@UserName", Username);
                    //cmd.Parameters.Add("@Branch", context.Session["branch"].ToString());
                }
                DataTable dtEmployee = vdm.SelectQuery(cmd).Tables[0];
                if (dtEmployee.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmployee.Rows)
                    {
                        PlantEmployee b = new PlantEmployee() { Employee_id = dr["Sno"].ToString(), EmployeeName = dr["EmpName"].ToString() };
                        Employeelist.Add(b);
                    }
                    string response = GetJson(Employeelist);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void GetSalesOfficeEmployee(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string DispSno = context.Request["DispSno"];
                string DispType = context.Request["DispType"];
                DataTable dtEmploye = new DataTable();
                if (DispType == "SO")
                {
                    cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName FROM empmanage INNER JOIN dispatch ON empmanage.Branch = dispatch.BranchID WHERE (dispatch.sno = @DispSno) AND (empmanage.LevelType = 'Dispatcher')");
                    cmd.Parameters.Add("@DispSno", DispSno);
                    dtEmploye = vdm.SelectQuery(cmd).Tables[0];
                }
                else if (DispType == "SM")
                {
                    cmd = new MySqlCommand("SELECT Sno, UserName FROM empmanage WHERE (Branch = @BranchID) AND (LevelType = 'Opperations')");
                    cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                    dtEmploye = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName FROM empmanage INNER JOIN dispatch ON empmanage.Branch = dispatch.BranchID WHERE (dispatch.sno = @DispSno) AND (empmanage.LevelType = 'Opperations')");
                    cmd.Parameters.Add("@DispSno", DispSno);
                    dtEmploye = vdm.SelectQuery(cmd).Tables[0];
                }
                List<PlantEmployee> Employeelist = new List<PlantEmployee>();
                if (dtEmploye.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtEmploye.Rows)
                    {
                        PlantEmployee GetEmployee = new PlantEmployee();
                        GetEmployee.Employee_id = dr["Sno"].ToString();
                        GetEmployee.EmployeeName = dr["UserName"].ToString();
                        Employeelist.Add(GetEmployee);
                    }
                }
                string errresponse = GetJson(Employeelist);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        private void get_Plant_TripRoutes(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtTotalDispatches = new DataTable();
                string Username = context.Session["userdata_sno"].ToString();
                List<Route> brnch = new List<Route>();
                List<Dispatchplan> DispatchplanList = new List<Dispatchplan>();
                cmd = new MySqlCommand("select sno,DispName from dispatch where Branch_Id=@branchid and flag<>0 order by sno");
                cmd.Parameters.Add("@branchid", context.Session["branch"].ToString());
                DataTable dtDispatches = vdm.SelectQuery(cmd).Tables[0];
                dtTotalDispatches.Columns.Add("sno");
                dtTotalDispatches.Columns.Add("DispName");
                dtTotalDispatches.Columns.Add("dispatchTime");
                dtTotalDispatches.Columns.Add("PlanStatus");
                dtTotalDispatches.Columns.Add("Plantime");
                dtTotalDispatches.Columns.Add("DespatchStatus");
                dtTotalDispatches.Columns.Add("EndStatus");
                dtTotalDispatches.Columns.Add("EndTime");
                foreach (DataRow dr in dtDispatches.Rows)
                {
                    DataRow newrow = dtTotalDispatches.NewRow();
                    newrow["sno"] = dr["sno"].ToString();
                    newrow["DispName"] = dr["DispName"].ToString();
                    newrow["dispatchTime"] = "";
                    newrow["PlanStatus"] = "";
                    newrow["Plantime"] = "";
                    newrow["DespatchStatus"] = "";
                    newrow["EndStatus"] = "";
                    newrow["EndTime"] = "";
                    dtTotalDispatches.Rows.Add(newrow);
                }
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("SELECT dispatch.DispName, dispatch.sno, tripdata.PlanStatus,tripdata.status as EndStatus,tripdata.Cdate ,tripdata.PlanTime,tripdata.DispTime, tripdata.AssignDate, tripdata.DespatchStatus FROM  tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno RIGHT OUTER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE  (dispatch.flag <> 0) AND  (dispatch.Branch_Id = @branchid) AND (tripdata.AssignDate BETWEEN @d1 AND @d2) GROUP BY dispatch.DispName order by dispatch.sno");
                cmd.Parameters.Add("@branchid", context.Session["branch"].ToString());
                cmd.Parameters.Add("@d1", GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", GetHighDate(ServerDateCurrentdate));
                DataTable dtAssignDisp = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow drtotal in dtTotalDispatches.Rows)
                {
                    foreach (DataRow dr in dtAssignDisp.Rows)
                    {
                        if (drtotal["sno"].ToString() == dr["sno"].ToString())
                        {
                            drtotal["dispatchTime"] = dr["DispTime"].ToString();
                            drtotal["PlanStatus"] = dr["PlanStatus"].ToString();
                            drtotal["Plantime"] = dr["Plantime"].ToString();
                            drtotal["DespatchStatus"] = dr["DespatchStatus"].ToString();
                            drtotal["EndStatus"] = dr["EndStatus"].ToString();
                            drtotal["EndTime"] = dr["Cdate"].ToString();
                        }
                    }
                }
                if (dtTotalDispatches.Rows.Count > 0)
                {
                    int i = 1;
                    foreach (DataRow dr in dtTotalDispatches.Rows)
                    {
                        Dispatchplan GetDispatch = new Dispatchplan();
                        GetDispatch.Sno = i++.ToString();
                        GetDispatch.Route_id = dr["Sno"].ToString();
                        GetDispatch.RouteName = dr["DispName"].ToString();
                        string DOE = dr["dispatchTime"].ToString();
                        if (DOE != "")
                        {
                            GetDispatch.DespTime = DOE;
                        }
                        else
                        {
                            string ChangedTime = "";
                            GetDispatch.DespTime = ChangedTime;
                        }
                        string Plantime = dr["Plantime"].ToString();
                        if (Plantime != "")
                        {
                            GetDispatch.PlanTime = Plantime;
                        }
                        else
                        {
                            string ChangedTime = "";
                            GetDispatch.PlanTime = ChangedTime;
                        }
                        string PlanStatus = dr["PlanStatus"].ToString();
                        if (PlanStatus == "")
                        {
                            PlanStatus = "Plan";
                        }
                        if (PlanStatus == "A")
                        {
                            PlanStatus = "Planned";
                        }
                        if (PlanStatus == "P")
                        {
                            PlanStatus = "Planned";
                        }
                        GetDispatch.PlantStatus = PlanStatus;
                        string EndStatus = dr["EndStatus"].ToString();
                        if (EndStatus == "A")
                        {
                            EndStatus = "Assign";
                        }
                        if (EndStatus == "P")
                        {
                            EndStatus = "Pending";
                        }
                        if (EndStatus == "V")
                        {
                            EndStatus = "Verified";
                        }
                        GetDispatch.EndStatus = EndStatus;
                        string EndTime = dr["EndTime"].ToString();
                        if (EndTime != "")
                        {
                            GetDispatch.EndTime = EndTime;
                        }
                        else
                        {
                            GetDispatch.EndTime = EndTime;
                        }
                        string DespatchStatus = dr["DespatchStatus"].ToString();
                        if (DespatchStatus == "")
                        {
                            DespatchStatus = "No";
                        }
                        GetDispatch.DespStatus = DespatchStatus;
                        DispatchplanList.Add(GetDispatch);
                    }
                    string response = GetJson(DispatchplanList);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        class Dispatchplan
        {
            public string Sno { set; get; }
            public string Route_id { set; get; }
            public string RouteName { set; get; }
            public string PlanTime { set; get; }
            public string DespTime { set; get; }
            public string PlantStatus { set; get; }
            public string DespStatus { set; get; }
            public string EndStatus { set; get; }
            public string EndTime { set; get; }
            public string tripid { set; get; }
        }
        private void FillCategeoryname(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string username = context.Session["userdata_sno"].ToString();
                    cmd = new MySqlCommand("select sno,Categoryname from products_category where flag=@flag and userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    cmd.Parameters.Add("@flag", "1");
                    List<Categoryclass> Categorylist = new List<Categoryclass>();
                    foreach (DataRow dr in vdm.SelectQuery(cmd).Tables[0].Rows)
                    {
                        Categoryclass getCategory = new Categoryclass();
                        getCategory.sno = dr["sno"].ToString();
                        getCategory.categoryname = dr["Categoryname"].ToString();
                        Categorylist.Add(getCategory);
                    }
                    if (context.Session["getbranchcategorynames"] == null)
                    {
                        cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                        cmd.Parameters.Add("@username", username);
                        DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["getbranchcategorynames"] = dt;
                    }
                    string response = GetJson(Categorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void AddBranchProducts(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string ProductSno = context.Request["ProductSno"];
                string Rate = context.Request["Rate"];
                string bid = context.Request["bid"];
                cmd = new MySqlCommand("update branchproducts set product_sno=@product_sno, flag=@flag where branch_sno=@branch_sno and userdata_sno=@userdata_sno");
                cmd.Parameters.AddWithValue("@branch_sno", bid);
                cmd.Parameters.AddWithValue("@product_sno", ProductSno);
                float UnitPrice = 0;
                cmd.Parameters.AddWithValue("@unitprice", UnitPrice);
                cmd.Parameters.AddWithValue("@flag", 1);
                cmd.Parameters.AddWithValue("@userdata_sno", 1);
                if (vdm.Update(cmd) == 0)
                {
                    cmd = new MySqlCommand("insert into branchproducts (branch_sno,product_sno,unitprice,flag,userdata_sno) values(@branch_sno,@product_sno,@unitprice,@flag,@userdata_sno)");
                    cmd.Parameters.AddWithValue("@branch_sno", bid);
                    cmd.Parameters.AddWithValue("@product_sno", ProductSno);
                    cmd.Parameters.AddWithValue("@unitprice", UnitPrice);
                    cmd.Parameters.AddWithValue("@flag", 1);
                    cmd.Parameters.AddWithValue("@userdata_sno", 1);
                    vdm.insert(cmd);
                }
            }
            catch
            {
            }
        }
        class Categoryclass
        {
            public string sno { set; get; }
            public string categoryname { set; get; }
        }
        private void get_product_subcategory_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<subCategoryclass> subCategorylist = new List<subCategoryclass>();
                string username = context.Session["userdata_sno"].ToString();
                string catgryname = context.Request["cmbcatgryname"];
                DataTable categorys = new DataTable();
                if (context.Session["getbranchcategorynames"] == null)
                {
                    cmd = new MySqlCommand("SELECT products_category.Categoryname, products_subcategory.SubCatName,products_subcategory.category_sno,products_subcategory.sno, productsdata.*  FROM productsdata RIGHT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno RIGHT OUTER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (products_category.flag<>0) AND (products_subcategory.Flag<>0) AND products_category.userdata_sno=@username");
                    cmd.Parameters.Add("@username", username);
                    DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                    context.Session["getbranchcategorynames"] = dt;
                }
                else
                {
                    categorys = (DataTable)context.Session["getbranchcategorynames"];
                }
                DataTable subcatgrynames = categorys.DefaultView.ToTable(true, "category_sno", "SubCatName", "sno");
                DataRow[] subcatgry = subcatgrynames.Select("category_sno=" + catgryname + "");
                foreach (DataRow dr in subcatgry)
                {
                    subCategoryclass GetsubCategory = new subCategoryclass();
                    GetsubCategory.sno = dr["sno"].ToString();
                    GetsubCategory.subcategorynames = dr["SubCatName"].ToString();
                    subCategorylist.Add(GetsubCategory);
                }
                if (subCategorylist != null)
                {
                    string response = GetJson(subCategorylist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        class subCategoryclass
        {
            public string sno { set; get; }
            public string subcategorynames { set; get; }
        }
        private void get_products_data(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<ProductNames> ProductNamesList = new List<ProductNames>();
                string username = context.Session["userdata_sno"].ToString();
                string subcatname = context.Request["cmbsubcatgryname"];
                DataTable subcategorys = new DataTable();
                //if (context.Session["leveltype"] == "Agent")
                //{
                //if (context.Session["getproductsnames"] == null)
                //{
                cmd = new MySqlCommand("SELECT productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno LEFT OUTER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno WHERE (products_subcategory.Flag <> 0) AND (productsdata.UserData_sno = @username) and productsdata.SubCat_sno=@subcatsno");
                //cmd = new MySqlCommand("SELECT productsdata.sno, productsdata.SubCat_sno, productsdata.ProductName, productsdata.Qty, productsdata.Units, productsdata.UnitPrice, productsdata.Flag, productsdata.UserData_sno, products_subcategory.SubCatName FROM products_subcategory RIGHT OUTER JOIN productsdata ON products_subcategory.sno = productsdata.SubCat_sno WHERE (products_subcategory.Flag <> 0) AND productsdata.UserData_sno=@username");
                cmd.Parameters.Add("@subcatsno", subcatname);
                cmd.Parameters.Add("@username", username);
                DataTable dt1 = vdm.SelectQuery(cmd).Tables[0];
                context.Session["getproductsnames"] = dt1;
                subcategorys = dt1;
                //}
                //else
                //{
                //    subcategorys = (DataTable)context.Session["getproductsnames"];
                //}
                DataTable productnames = subcategorys.DefaultView.ToTable(true, "SubCat_sno", "ProductName", "sno");
                DataRow[] products = productnames.Select("SubCat_sno=" + subcatname + "");
                foreach (DataRow dr in products)
                {
                    ProductNames GetProduct = new ProductNames();
                    GetProduct.productName = dr["ProductName"].ToString();
                    GetProduct.Sno = dr["sno"].ToString();
                    ProductNamesList.Add(GetProduct);
                }
                //if (ProductNamesList != null)
                //{
                string response = GetJson(ProductNamesList);
                context.Response.Write(response);
                //}
                //}
            }
            catch
            {
            }
        }
        public class ProductNames
        {
            public string productName { get; set; }
            public string Qty { get; set; }
            public string Sno { get; set; }
        }
        private void GetProductNamechange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Sno = context.Request["ProductSno"];
                string BranchID = context.Request["BranchID"];
                List<ProductUnit> ProductList = new List<ProductUnit>();
                cmd = new MySqlCommand("SELECT branchproducts.unitprice, branchproducts.product_sno, productsdata.Qty, productsdata.Units FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) and (branchproducts.product_sno=@sno) ");
                cmd.Parameters.Add("@sno", Sno);
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtBranchProduct = vdm.SelectQuery(cmd).Tables[0];
                string AunitPrice = "0";
                if (dtBranchProduct.Rows.Count > 0)
                {
                    AunitPrice = dtBranchProduct.Rows[0]["unitprice"].ToString();
                }
                if (AunitPrice == "0")
                {
                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,productsdata.Qty, productsdata.Units, branchproducts.product_sno, branchproducts.unitprice AS Bunitprice , productsdata.ProductName FROM productsdata INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch WHERE (branchmappingtable.SubBranch = @BranchID) AND (branchproducts.product_sno = @Sno)");
                    cmd.Parameters.Add("@sno", Sno);
                    cmd.Parameters.Add("@BranchID", BranchID);
                    DataTable dtProduct = vdm.SelectQuery(cmd).Tables[0];
                    ProductUnit GetProduct = new ProductUnit();
                    if (dtProduct.Rows.Count > 0)
                    {
                        GetProduct.UnitPrice = dtProduct.Rows[0]["UnitPrice"].ToString();
                        GetProduct.Unitqty = dtProduct.Rows[0]["Qty"].ToString();
                        GetProduct.Units = dtProduct.Rows[0]["Units"].ToString();
                        string BranchUnitPrice = dtProduct.Rows[0]["BUnitPrice"].ToString();
                        float Rate = 0;
                        if (BranchUnitPrice != "0")
                        {
                            Rate = (float)dtProduct.Rows[0]["BUnitPrice"];
                        }
                        else
                        {
                            Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                        }
                        //float Rate = (float)dtProduct.Rows[0]["UnitPrice"];
                        float Unitqty = (float)dtProduct.Rows[0]["Qty"];
                        float TotalRate = 0;
                        if (dtProduct.Rows[0]["Units"].ToString() == "ml")
                        {
                            TotalRate = Rate;
                        }
                        if (dtProduct.Rows[0]["Units"].ToString() == "ltr")
                        {
                            TotalRate = Rate;
                        }
                        if (dtProduct.Rows[0]["Units"].ToString() == "gms")
                        {
                            TotalRate = Rate;
                        }
                        if (dtProduct.Rows[0]["Units"].ToString() == "kgs")
                        {
                            TotalRate = Rate;
                        }
                        if (dtProduct.Rows[0]["Units"].ToString() == "ml" || dtProduct.Rows[0]["Units"].ToString() == "ltr")
                        {
                            GetProduct.Desciption = "Ltrs";
                        }
                        else
                        {
                            GetProduct.Desciption = "Kgs";
                        }
                        //getOrderValue.Rate = (float)Rate;
                        GetProduct.orderunitRate = (float)TotalRate;
                    }
                    else
                    {
                        string Unitqty = "0"; string Desciption = "";
                        //GetProduct.UnitPrice =
                        //GetProduct.UnitPrice =
                        // GetProduct.UnitPrice =
                        GetProduct.Desciption = "";
                        GetProduct.Unitqty = "";
                    }
                    ProductList.Add(GetProduct);
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
                else
                {
                    ProductUnit GetProduct = new ProductUnit();
                    if (dtBranchProduct.Rows.Count > 0)
                    {

                        GetProduct.UnitPrice = dtBranchProduct.Rows[0]["UnitPrice"].ToString();
                        GetProduct.Unitqty = dtBranchProduct.Rows[0]["Qty"].ToString();
                        GetProduct.Units = dtBranchProduct.Rows[0]["Units"].ToString();
                        float Rate = (float)dtBranchProduct.Rows[0]["UnitPrice"];
                        float Unitqty = (float)dtBranchProduct.Rows[0]["Qty"];
                        float TotalRate = 0;
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml")
                        {
                            TotalRate = Rate;
                        }
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                        {
                            TotalRate = Rate;
                        }
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "gms")
                        {
                            TotalRate = Rate;
                        }
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "kgs")
                        {
                            TotalRate = Rate;
                        }
                        if (dtBranchProduct.Rows[0]["Units"].ToString() == "ml" || dtBranchProduct.Rows[0]["Units"].ToString() == "ltr")
                        {
                            GetProduct.Desciption = "Ltrs";
                        }
                        else
                        {
                            GetProduct.Desciption = "Kgs";
                        }
                        //getOrderValue.Rate = (float)Rate;
                        GetProduct.orderunitRate = (float)TotalRate;
                        ProductList.Add(GetProduct);
                    }
                    else
                    {
                        string Unitqty = "0"; string Desciption = "";
                        //GetProduct.UnitPrice =
                        //GetProduct.UnitPrice =
                        // GetProduct.UnitPrice =
                        GetProduct.Desciption = "";
                        GetProduct.Unitqty = "";
                        ProductList.Add(GetProduct);
                    }
                    string response = GetJson(ProductList);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        public class ProductUnit
        {
            public string UnitPrice { get; set; }
            public string Unitqty { get; set; }
            public string Units { get; set; }
            public float orderunitRate { get; set; }
            public string Desciption { get; set; }
        }
        private void btnOrderSaveClick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                var js = new JavaScriptSerializer();
                List<string> MsgList = new List<string>();
                if (context.Session["userdata_sno"] == null)
                {
                    string errmsg = "Session Expired";
                    string errresponse = GetJson(errmsg);
                    context.Response.Write(errresponse);
                }
                else
                {
                    string Username = context.Session["userdata_sno"].ToString();
                    DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                    var title1 = context.Request.Params[1];
                    Orders obj = js.Deserialize<Orders>(title1);
                    string b_bid = obj.BranchID;
                    string IndentType = obj.IndentType;
                    if (IndentType == "")
                    {
                        IndentType = "Indent1";
                    }
                    if (IndentType == null)
                    {
                        IndentType = "Indent1";
                    }
                    cmd = new MySqlCommand("select BranchName,phonenumber from BranchData where Sno=@sno");
                    cmd.Parameters.Add("@sno", b_bid);
                    DataTable dtBranchName = vdm.SelectQuery(cmd).Tables[0];
                    string BranchName = dtBranchName.Rows[0]["BranchName"].ToString();
                    string phonenumber = dtBranchName.Rows[0]["phonenumber"].ToString();
                    int BranchID = 0;
                    int.TryParse(b_bid, out BranchID);
                    float Qty = 0;
                    float.TryParse(obj.totqty, out Qty);
                    float Price = 0;
                    float.TryParse(obj.totTotal, out Price);
                    float TotalPrice = 0;
                    float.TryParse(obj.TotalPrice, out TotalPrice);
                    DataTable dtorders = new DataTable();
                    if (context.Session["Orders"] == null)
                    {
                        cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2)");
                        cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                        cmd.Parameters.Add("@UserName", Username);
                        cmd.Parameters.Add("@IndentType", IndentType);
                        cmd.Parameters.Add("@bsno", b_bid);
                        dtorders = vdm.SelectQuery(cmd).Tables[0];
                        context.Session["Orders"] = dtorders;
                    }
                    else
                    {
                        dtorders = (DataTable)context.Session["Orders"];
                    }
                    DataRow[] drOrders;
                    string hdnIndentNo = obj.IndentNo;
                    cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType = @IndentType)");
                    cmd.Parameters.Add("@Branch_id", BranchID);
                    cmd.Parameters.Add("@IndentType", IndentType);
                    cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                    cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                    DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                    string ProductName = "";
                    double TotalQty = 0;
                    double OfferTotalQty = 0;
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Unitsqty != "0")
                        {
                            float UnitQty = 0;
                            float.TryParse(o.Unitsqty, out UnitQty);
                            ProductName += o.Product + "-->" + Math.Round(UnitQty, 2) + ";\r\n";
                            TotalQty += Math.Round(UnitQty, 2);
                        }
                    }
                    if (dtIndent.Rows.Count > 0)
                    {
                        string BranchIndentNo = dtIndent.Rows[0]["IndentNo"].ToString();
                        if (BranchIndentNo != "")
                        {
                            cmd = new MySqlCommand("Update indents set I_date=@I_date, UserData_sno=@UserData_sno, Status=@Status,I_modifiedby=@I_modifiedby where Branch_id=@Branch_id and IndentNo=@IndentNo");
                            cmd.Parameters.Add("@Branch_id", BranchID);
                            cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@UserData_sno", Username);
                            cmd.Parameters.Add("@Status", "O");
                            cmd.Parameters.Add("@I_modifiedby", context.Session["UserSno"].ToString());
                            cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                            vdm.Update(cmd);
                            foreach (orderdetail o in obj.data)
                            {
                                //cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,OTripId=@OTripId,UnitCost=@UnitCost,Status=@Status where IndentNo=@IndentNo and Product_sno=@Product_sno");
                                cmd = new MySqlCommand("Update indents_subtable set unitQty=@unitQty,UnitCost=@UnitCost,Status=@Status where IndentNo=@IndentNo and Product_sno=@Product_sno");
                                cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                double UnitCost = 0;
                                double.TryParse(o.UnitCost, out UnitCost);
                                UnitCost = Math.Round(UnitCost, 2);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                //cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                if (vdm.Update(cmd) == 0)
                                {
                                    //cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                    cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost)");
                                    cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    cmd.Parameters.Add("@UnitCost", UnitCost);
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    cmd.Parameters.Add("@Status", "Ordered");
                                    //cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                                foreach (DataRow dr in dtorders.Rows)
                                {
                                    string Prodsno = dr["sno"].ToString();
                                    string Psno = o.Productsno;
                                    if (Prodsno == Psno)
                                    {
                                        cmd = new MySqlCommand("Update  EditedIndents set Prodsno=@Prodsno,EntryTime=@EntryTime,ActualQty=@ActualQty,EditQty=@EditQty where BranchID=@BranchID and IndentNo=@IndentNo");
                                        cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                        cmd.Parameters.Add("@Prodsno", o.Productsno);
                                        cmd.Parameters.Add("@BranchID", b_bid);
                                        cmd.Parameters.Add("@EntryTime", ServerDateCurrentdate);
                                        double Aqty = 0;
                                        double.TryParse(dr["unitQty"].ToString(), out Aqty);
                                        Aqty = Math.Round(Aqty, 2);
                                        cmd.Parameters.Add("@ActualQty", Aqty);
                                        double Eqty = 0;
                                        double.TryParse(o.ReturnQty, out Eqty);
                                        Eqty = Math.Round(Eqty, 2);
                                        cmd.Parameters.Add("@EditQty", Eqty);
                                        if (vdm.Update(cmd) == 0)
                                        {
                                            cmd = new MySqlCommand("insert into EditedIndents (IndentNo,Prodsno,BranchID,EntryTime,ActualQty,EditQty)values(@IndentNo,@Prodsno,@BranchID,@EntryTime,@ActualQty,@EditQty)");
                                            cmd.Parameters.Add("@IndentNo", BranchIndentNo);
                                            cmd.Parameters.Add("@Prodsno", o.Productsno);
                                            cmd.Parameters.Add("@BranchID", b_bid);
                                            cmd.Parameters.Add("@EntryTime", ServerDateCurrentdate);
                                            cmd.Parameters.Add("@ActualQty", Aqty);
                                            cmd.Parameters.Add("@EditQty", Eqty);
                                            vdm.insert(cmd);
                                        }
                                    }
                                }
                            }
                            cmd = new MySqlCommand("Update Indents set PaymentStatus=@PamentStatus where IndentNo=@IndentNo");
                            cmd.Parameters.Add("@PamentStatus", 'A');
                            cmd.Parameters.Add("@IndentNo", hdnIndentNo);
                            vdm.Update(cmd);
                        }
                        else
                        {
                            cmd = new MySqlCommand("insert into indents (Branch_id,TotalQty,TotalPrice,I_date,UserData_sno,Status,PaymentStatus,I_createdby,IndentType)values(@Branch_id,@TotalQty,@TotalPrice,@I_date,@UserData_sno,@Status,@PaymentStatus,@I_createdby,@IndentType)");
                            cmd.Parameters.Add("@Branch_id", BranchID);
                            cmd.Parameters.Add("@TotalQty", Qty);
                            cmd.Parameters.Add("@TotalPrice", Price);
                            cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                            cmd.Parameters.Add("@UserData_sno", Username);
                            cmd.Parameters.Add("@Status", "O");
                            cmd.Parameters.Add("@PaymentStatus", 'A');
                            cmd.Parameters.Add("@IndentType", IndentType);
                            long IndentNo = vdm.insertScalar(cmd);
                            foreach (orderdetail o in obj.data)
                            {
                                if (o.Productsno != null)
                                {
                                    cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost)");
                                    cmd.Parameters.Add("@IndentNo", IndentNo);
                                    cmd.Parameters.Add("@Product_sno", o.Productsno);
                                    double UnitCost = 0;
                                    double.TryParse(o.UnitCost, out UnitCost);
                                    UnitCost = Math.Round(UnitCost, 2);
                                    cmd.Parameters.Add("@UnitCost", UnitCost);
                                    double unitQty = 0;
                                    double.TryParse(o.Unitsqty, out unitQty);
                                    unitQty = Math.Round(unitQty, 2);
                                    cmd.Parameters.Add("@unitQty", unitQty);
                                    cmd.Parameters.Add("@Status", "Ordered");
                                    //cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                    if (unitQty != 0.0)
                                    {
                                        vdm.insert(cmd);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        cmd = new MySqlCommand("insert into indents (Branch_id,TotalQty,TotalPrice,I_date,UserData_sno,Status,PaymentStatus,IndentType)values(@Branch_id,@TotalQty,@TotalPrice,@I_date,@UserData_sno,@Status,@PaymentStatus,@IndentType)");
                        cmd.Parameters.Add("@Branch_id", BranchID);
                        cmd.Parameters.Add("@TotalQty", Qty);
                        cmd.Parameters.Add("@TotalPrice", Price);
                        cmd.Parameters.Add("@I_date", ServerDateCurrentdate);
                        cmd.Parameters.Add("@UserData_sno", Username);
                        cmd.Parameters.Add("@Status", "O");
                        cmd.Parameters.Add("@IndentType", IndentType);
                        cmd.Parameters.Add("@PaymentStatus", 'A');
                        long IndentNo = vdm.insertScalar(cmd);
                        foreach (orderdetail o in obj.data)
                        {
                            if (o.Productsno != null)
                            {
                                //cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost,OTripId)values(@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost,@OTripId)");
                                cmd = new MySqlCommand("insert into indents_subtable (IndentNo,Product_sno,Status,unitQty,UnitCost)  values (@IndentNo,@Product_sno,@Status,@unitQty,@UnitCost)");
                                cmd.Parameters.Add("@IndentNo", IndentNo);
                                cmd.Parameters.Add("@Product_sno", o.Productsno);
                                double UnitCost = 0;
                                double.TryParse(o.UnitCost, out UnitCost);
                                UnitCost = Math.Round(UnitCost, 2);
                                cmd.Parameters.Add("@UnitCost", UnitCost);
                                double unitQty = 0;
                                double.TryParse(o.Unitsqty, out unitQty);
                                unitQty = Math.Round(unitQty, 2);
                                cmd.Parameters.Add("@unitQty", unitQty);
                                cmd.Parameters.Add("@Status", "Ordered");
                                //cmd.Parameters.Add("@OTripId", context.Session["TripdataSno"].ToString());
                                if (unitQty != 0.0)
                                {
                                    vdm.insert(cmd);
                                }
                            }
                        }
                    }
                    foreach (orderdetail o in obj.data)
                    {
                        if (o.Productsno != null)
                        {
                            cmd = new MySqlCommand("Update branchproducts set flag=@flag  where branch_sno=@branch_sno and product_sno=@product_sno");
                            float UnitCost = 0;
                            cmd.Parameters.Add("@flag", true);
                            cmd.Parameters.Add("@branch_sno", BranchID);
                            cmd.Parameters.Add("@product_sno", o.Productsno);
                            if (vdm.Update(cmd) == 0)
                            {
                                cmd = new MySqlCommand("Insert Into branchproducts(branch_sno,product_sno,flag,userdata_sno,Unitprice) values(@branch_sno,@product_sno,@flag,@userdata_sno,@Unitprice)");
                                cmd.Parameters.Add("@branch_sno", BranchID);
                                cmd.Parameters.Add("@product_sno", o.Productsno);
                                cmd.Parameters.Add("@flag", false);
                                cmd.Parameters.Add("@userdata_sno", Username);
                                cmd.Parameters.Add("@Unitprice", UnitCost);
                                vdm.insert(cmd);
                            }
                        }
                    }
                    if (phonenumber.Length == 10)
                    {
                        string Date = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                        WebClient client = new WebClient();
                        string companyname = "\r\nPowered By Vyshnavi";
                        string baseurl = "http://103.225.76.43/blank/sms/user/urlsms.php?username=AsnTech&pass=AsnTech@user!123&senderid=VSNAVI&dest_mobileno=" + phonenumber + "&message=Dear%20" + BranchName + "%20Your%20indent%20for%20tomorrow%20Date%20" + Date + "%20,%20" + ProductName + "Total%20Ltrs ->" + TotalQty + "\r\n" + companyname + "&response=Y";
                        Stream data = client.OpenRead(baseurl);
                        StreamReader reader = new StreamReader(data);
                        string ResponseID = reader.ReadToEnd();
                        data.Close();
                        reader.Close();
                    }
                    var jsonSerializer = new JavaScriptSerializer();
                    var jsonString = String.Empty;
                    context.Request.InputStream.Position = 0;
                    using (var inputStream = new StreamReader(context.Request.InputStream))
                    {
                        jsonString = inputStream.ReadToEnd();
                    }
                    string msg = "Data Successfully Saved";
                    MsgList.Add(msg);
                    string responses = GetJson(MsgList);
                    context.Response.Write(responses);
                }
            }
            catch (Exception ex)
            {
                List<string> MsgList = new List<string>();
                if (ex.Message == "Unable to connect to the remote server")
                {
                    string msg = "Data Saved but Message Not Sent";
                    MsgList.Add(msg);
                }
                else
                {
                    string msg = ex.ToString();
                    MsgList.Add(msg);
                }

                string response = GetJson(MsgList);
                context.Response.Write(response);
            }
        }
        private void GetDispatchAgents(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Route> Routelist = new List<Route>();
                string salestype = "";
                cmd = new MySqlCommand("SELECT branchroutes.RouteName, branchroutes.Sno FROM branchroutes INNER JOIN branchdata ON branchroutes.BranchID = branchdata.sno INNER JOIN branchdata branchdata_1 ON branchroutes.BranchID = branchdata_1.sno WHERE  (branchdata_1.SalesOfficeID = @BranchID) OR  (branchdata.sno = @BID) and (branchroutes.flag=1)");
                //cmd = new MySqlCommand("SELECT branchroutes.RouteName, branchroutes.Sno  FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutes ON dispatch.Route_id = branchroutes.Sno WHERE (triproutes.Tripdata_sno = @TripId) and (" + querycond + ")  GROUP BY branchroutes.RouteName");
                cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                cmd.Parameters.Add("@BID", context.Session["branch"].ToString());
                //  cmd.Parameters.Add("@dispatchsno", querycond);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtBranch.Rows)
                {
                    Route b = new Route() { rid = dr["Sno"].ToString(), RouteName = dr["RouteName"].ToString() };
                    Routelist.Add(b);
                }
                string response = GetJson(Routelist);
                context.Response.Write(response);
                //else
                //{
                //    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN dispatch ON empmanage.Branch = dispatch.Branch_Id INNER JOIN branchroutesubtable ON dispatch.Route_id = branchroutesubtable.RefNo INNER JOIN  branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (triproutes.Tripdata_sno = @TripId) GROUP BY branchdata.BranchName");
                //    cmd.Parameters.Add("@TripId", context.Session["TripdataSno"].ToString());
                //    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                //    List<Branch> brnch = new List<Branch>();
                //    foreach (DataRow dr in dtBranch.Rows)
                //    {
                //        Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString() };
                //        brnch.Add(b);
                //    }
                //    string response = GetJson(brnch);
                //    context.Response.Write(response);
                //}
            }
            catch
            {
            }
        }
        private void GetSoRoutes(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                cmd = new MySqlCommand("SELECT Sno, RouteName FROM branchroutes WHERE (BranchID = @BranchID)");
                cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                DataTable dtRoute = vdm.SelectQuery(cmd).Tables[0];
                List<Route> Routelist = new List<Route>();
                foreach (DataRow dr in dtRoute.Rows)
                {
                    Route b = new Route() { rid = dr["Sno"].ToString(), RouteName = dr["RouteName"].ToString() };
                    Routelist.Add(b);
                }
                string response = GetJson(Routelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void getBranchValues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                if (context.Request["bid"] != null)
                {
                    List<string> MsgList = new List<string>();
                    if (context.Session["userdata_sno"] == null)
                    {
                        string errmsg = "Session Expired";
                        string errresponse = GetJson(errmsg);
                        context.Response.Write(errresponse);
                    }
                    else
                    {
                        string Username = context.Session["userdata_sno"].ToString();
                        string DairyStatus = context.Request["DairyStatus"];
                        string IndentType = context.Request["IndentType"];
                        if (IndentType == "")
                        {
                            IndentType = context.Session["IndentType"].ToString();
                        }
                        if (IndentType == "")
                        {
                            IndentType = "Indent1";
                        }
                        if (IndentType == null)
                        {
                            IndentType = "Indent1";
                        }
                        List<Orderclass> OrderList = new List<Orderclass>();
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        #region-------->ORDERS<-----------
                        if (DairyStatus == "Orders")
                        {
                            //By sundeep cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2)");
                            cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, branchproducts_1.Rank,indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.unitprice AS BUnitPrice, branchproducts.branch_sno, branchmappingtable.SuperBranch, indents.I_date, branchproducts_1.unitprice AS SOUnitPrice, branchproducts.flag FROM indents INNER JOIN branchproducts ON indents.Branch_id = branchproducts.branch_sno INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SubBranch INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SuperBranch = branchproducts_1.branch_sno AND  branchproducts.product_sno = branchproducts_1.product_sno LEFT OUTER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo AND branchproducts.product_sno = indents_subtable.Product_sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents.Branch_id = @bsno) AND (indents.IndentType = @IndentType) ORDER BY branchproducts_1.Rank");
                            cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate));
                            cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate));
                            cmd.Parameters.Add("@UserName", Username);
                            cmd.Parameters.Add("@IndentType", IndentType);
                            cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                            DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                            context.Session["Orders"] = dtBranch;
                            if (dtBranch.Rows.Count == 0)
                            {
                                cmd = new MySqlCommand("SELECT productsdata.ProductName,branchproducts_1.Rank,productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.unitprice AS BUnitPrice, branchproducts.branch_sno, branchmappingtable.SuperBranch, branchproducts_1.unitprice AS SOUnitPrice FROM indents_subtable INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno AND indents.Branch_id = branchproducts.branch_sno INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SubBranch INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SuperBranch = branchproducts_1.branch_sno AND branchproducts.product_sno = branchproducts_1.product_sno WHERE (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date between @d1 AND  @d2) AND (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.branch_sno ORDER BY branchproducts_1.Rank");
                                // cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.branch_sno, branchproducts.unitprice AS BUnitPrice FROM  indents_subtable INNER JOIN  productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno WHERE  (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2) AND  (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.product_sno ORDER BY productsdata.sno");
                                //cmd = new MySqlCommand("SELECT productsdata.ProductName, productsdata.UnitPrice, indents_subtable.unitQty, indents_subtable.UnitCost, productsdata.sno,  indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty, productsdata.Units, branchproducts.branch_sno,  branchproducts.unitprice AS BUnitPrice FROM indents_subtable INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno AND indents.Branch_id = branchproducts.branch_sno WHERE (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2) AND  (indents.Branch_id = @bsno) GROUP BY productsdata.ProductName, indents.Branch_id, branchproducts.product_sno ORDER BY productsdata.sno");
                                // cmd = new MySqlCommand("SELECT productsdata.ProductName,indents_subtable.unitQty,indents_subtable.unitCost, productsdata.sno, indents_subtable.unitQty * indents_subtable.UnitCost AS Total, indents.IndentNo, productsdata.Qty AS RawQty , productsdata.Units FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  and (indents.IndentType = @IndentType) AND (indents.UserData_sno = @UserName) AND (indents.I_date > @d1) AND (indents.I_date < @d2)");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(Currentdate.AddDays(-1)));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(Currentdate.AddDays(-1)));
                                cmd.Parameters.Add("@flag", 1);
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                if (dtBranch.Rows.Count == 0)
                                {
                                    cmd = new MySqlCommand("SELECT productsdata.UnitPrice,branchproducts.Rank, productsdata.ProductName, productsdata.Units, productsdata.Qty, branchproducts.unitprice AS BUnitPrice, branchproducts_1.unitprice AS Aunitprice, productsdata.sno FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno INNER JOIN branchproducts branchproducts_1 ON branchmappingtable.SubBranch = branchproducts_1.branch_sno AND  productsdata.sno = branchproducts_1.product_sno WHERE (branchproducts_1.branch_sno = @bsno) AND (branchproducts_1.flag = @flag)GROUP BY branchproducts_1.branch_sno, branchproducts_1.unitprice, productsdata.sno, branchproducts_1.flag ORDER BY branchproducts.Rank");
                                    //cmd = new MySqlCommand("SELECT productsdata.UnitPrice, productsdata.ProductName, productsdata.Units, productsdata.Qty,branchproducts.UnitPrice as BUnitPrice, productsdata.sno FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.userdata_sno = @UserName) AND (branchproducts.branch_sno = @bsno) AND (branchproducts.flag = @flag)");
                                    //cmd.Parameters.Add("@UserName", Username);
                                    cmd.Parameters.Add("@flag", 1);
                                    cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                    dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                    if (dtBranch.Rows.Count > 0)
                                    {
                                        int i = 1;
                                        foreach (DataRow dr in dtBranch.Rows)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            getOrderValue.Productsno = dr["sno"].ToString();

                                            getOrderValue.Qty = 0;
                                            getOrderValue.Total = 0;
                                            if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                            {
                                                getOrderValue.Desciption = "Ltrs";
                                            }
                                            else
                                            {
                                                getOrderValue.Desciption = "Kgs";
                                            }
                                            getOrderValue.Units = dr["Units"].ToString();
                                            getOrderValue.Unitqty = dr["Qty"].ToString();
                                            string AgentUnitPrice = dr["Aunitprice"].ToString();
                                            string BranchUnitPrice = dr["BUnitPrice"].ToString();
                                            float Rate = 0;
                                            if (AgentUnitPrice != "0")
                                            {
                                                Rate = (float)dr["Aunitprice"];
                                            }
                                            if (Rate == 0)
                                            {
                                                Rate = (float)dr["BUnitPrice"];
                                            }
                                            if (Rate == 0)
                                            {
                                                Rate = (float)dr["unitprice"];
                                            }
                                            float Unitqty = (float)dr["Qty"];
                                            float TotalRate = 0;
                                            if (dr["Units"].ToString() == "ml")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "ltr")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "gms")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "kgs")
                                            {
                                                TotalRate = Rate;
                                            }
                                            getOrderValue.Rate = (float)Rate;
                                            getOrderValue.orderunitRate = (float)TotalRate;
                                            getOrderValue.PrevQty = 0;
                                            getOrderValue.orderunitqty = "";
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                    else
                                    {
                                        Orderclass getOrderValue = new Orderclass();
                                        getOrderValue.sno = "";
                                        getOrderValue.ProductCode = "";
                                        getOrderValue.Productsno = "0";
                                        getOrderValue.Qty = 0;
                                        getOrderValue.Total = 0;
                                        getOrderValue.Desciption = "";
                                        getOrderValue.Units = "";
                                        getOrderValue.Unitqty = "";
                                        float Rate = 0;
                                        float TotalRate = 0;
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        getOrderValue.PrevQty = 0;
                                        getOrderValue.orderunitqty = "";
                                        OrderList.Add(getOrderValue);
                                    }
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                                else
                                {
                                    int i = 1;
                                    foreach (DataRow dr in dtBranch.Rows)
                                    {
                                        Orderclass getOrderValue = new Orderclass();
                                        getOrderValue.sno = i++.ToString();
                                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                                        getOrderValue.Productsno = dr["sno"].ToString();
                                        float UnitQty = 0;
                                        if (dr["UnitQty"].ToString() == "")
                                        {
                                            UnitQty = 0;
                                        }
                                        else
                                        {
                                            UnitQty = (float)dr["UnitQty"];
                                        }
                                        //float qty = (float)UnitQty;
                                        getOrderValue.Qty = Math.Round(UnitQty, 2);
                                        //float Rate = (float)dr["unitCost"];
                                        string BranchUnitPrice = dr["BUnitPrice"].ToString();
                                        if (BranchUnitPrice == "")
                                        {
                                            BranchUnitPrice = "0";
                                        }
                                        float Rate = 0;
                                        if (BranchUnitPrice != "0")
                                        {
                                            Rate = (float)dr["BUnitPrice"];
                                        }
                                        if (Rate == 0)
                                        {

                                            if (dr["SOUnitPrice"].ToString() == "")
                                            {
                                            }
                                            else
                                            {
                                                Rate = (float)dr["SOUnitPrice"];
                                            }
                                        }
                                        if (Rate == 0)
                                        {
                                            Rate = (float)dr["UnitPrice"];
                                        }
                                        float Unitqty = (float)dr["RawQty"];
                                        float TotalRate = 0;
                                        if (dr["Units"].ToString() == "ml")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "ltr")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "gms")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "kgs")
                                        {
                                            TotalRate = Rate;
                                        }
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        double Total = 0;
                                        if (dr["Total"].ToString() == "")
                                        {
                                            Total = 0;
                                        }
                                        else
                                        {
                                            Total = (double)dr["Total"];
                                        }
                                        double Dtotal = (double)Total;
                                        getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                        if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                        {
                                            getOrderValue.Desciption = "Ltrs";
                                        }
                                        else
                                        {
                                            getOrderValue.Desciption = "Kgs";
                                        }
                                        getOrderValue.Units = dr["Units"].ToString();
                                        getOrderValue.Unitqty = dr["RawQty"].ToString();
                                        getOrderValue.orderunitqty = "";
                                        float PrevQty = 0;
                                        float.TryParse(dr["UnitQty"].ToString(), out PrevQty);
                                        getOrderValue.PrevQty = Math.Round(PrevQty, 2);

                                        OrderList.Add(getOrderValue);
                                    }
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                            }
                            else
                            {
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    float qty = 0;
                                    float Rate = 0;
                                    Orderclass getOrderValue = new Orderclass();
                                    if (dr["flag"].ToString() == "1")
                                    {
                                        getOrderValue.sno = i++.ToString();
                                        getOrderValue.ProductCode = dr["ProductName"].ToString();
                                        getOrderValue.Productsno = dr["sno"].ToString();

                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            qty = (float)dr["UnitQty"];
                                        }
                                        else
                                        {
                                            qty = 0;
                                        }
                                        getOrderValue.Qty = Math.Round(qty, 2);
                                        if (dr["unitCost"].ToString() != "")
                                        {
                                            Rate = (float)dr["unitCost"];
                                        }
                                        else
                                        {
                                            float bunitprice = 0;
                                            float.TryParse(dr["BUnitPrice"].ToString(), out bunitprice);
                                            if (bunitprice == 0)
                                            {
                                                float SOunitprice = 0;
                                                float.TryParse(dr["SOUnitPrice"].ToString(), out SOunitprice);
                                                Rate = SOunitprice;
                                            }
                                            else
                                            {
                                                Rate = bunitprice;
                                            }
                                        }
                                        //Rate = (float)dr["unitCost"];
                                        float Unitqty = (float)dr["RawQty"];
                                        float TotalRate = 0;
                                        if (dr["Units"].ToString() == "ml")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "ltr")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "gms")
                                        {
                                            TotalRate = Rate;
                                        }
                                        if (dr["Units"].ToString() == "kgs")
                                        {
                                            TotalRate = Rate;
                                        }
                                        getOrderValue.Rate = (float)Rate;
                                        getOrderValue.orderunitRate = (float)TotalRate;
                                        double Dtotal = 0;
                                        if (dr["Total"].ToString() != "")
                                        {
                                            Dtotal = (double)dr["Total"];
                                        }
                                        else
                                        {
                                            Dtotal = 0;
                                        }
                                        // Dtotal = (double)dr["Total"];
                                        getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                        getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                        if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                        {
                                            getOrderValue.Desciption = "Ltrs";
                                        }
                                        else
                                        {
                                            getOrderValue.Desciption = "Kgs";
                                        }
                                        getOrderValue.Units = dr["Units"].ToString();
                                        getOrderValue.Unitqty = dr["RawQty"].ToString();
                                        getOrderValue.orderunitqty = dr["UnitQty"].ToString();
                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                    else
                                    {
                                        if (dr["UnitQty"].ToString() != "")
                                        {
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            //getOrderValue.Productsno = (int)dr["sno"];
                                            //qty=(float)dr["UnitQty"];
                                            if (dr["UnitQty"].ToString() != "")
                                            {
                                                qty = (float)dr["UnitQty"];
                                            }
                                            else
                                            {
                                                qty = 0;
                                            }
                                            getOrderValue.Qty = (float)Math.Round(qty, 2);
                                            if (dr["unitCost"].ToString() != "")
                                            {
                                                Rate = (float)dr["unitCost"];
                                            }
                                            else
                                            {
                                                float bunitprice = 0;
                                                float.TryParse(dr["BUnitPrice"].ToString(), out bunitprice);

                                                if (bunitprice == 0)
                                                {
                                                    float SOunitprice = 0;
                                                    float.TryParse(dr["SOUnitPrice"].ToString(), out SOunitprice);
                                                    Rate = SOunitprice;
                                                }
                                                else
                                                {
                                                    Rate = bunitprice;
                                                }
                                            }
                                            //Rate = (float)dr["unitCost"];
                                            float Unitqty = (float)dr["RawQty"];
                                            float TotalRate = 0;
                                            if (dr["Units"].ToString() == "ml")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "ltr")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "gms")
                                            {
                                                TotalRate = Rate;
                                            }
                                            if (dr["Units"].ToString() == "kgs")
                                            {
                                                TotalRate = Rate;
                                            }
                                            getOrderValue.Rate = (float)Rate;
                                            getOrderValue.orderunitRate = (float)TotalRate;
                                            double Dtotal = 0;
                                            if (dr["Total"].ToString() != "")
                                            {
                                                Dtotal = (double)dr["Total"];
                                            }
                                            else
                                            {
                                                Dtotal = 0;
                                            }
                                            // Dtotal = (double)dr["Total"];
                                            getOrderValue.Total = (double)Math.Round(Dtotal, 2);
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            if (dr["Units"].ToString() == "ml" || dr["Units"].ToString() == "ltr")
                                            {
                                                getOrderValue.Desciption = "Ltrs";
                                            }
                                            else
                                            {
                                                getOrderValue.Desciption = "Kgs";
                                            }
                                            getOrderValue.Units = dr["Units"].ToString();
                                            getOrderValue.Unitqty = dr["RawQty"].ToString();
                                            getOrderValue.orderunitqty = dr["UnitQty"].ToString();
                                            if (dr["UnitQty"].ToString() != "")
                                            {
                                                OrderList.Add(getOrderValue);
                                            }
                                        }
                                    }
                                }
                                if (OrderList.Count > 0)
                                {
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                                else
                                {
                                    Orderclass getOrderValue = new Orderclass();
                                    getOrderValue.sno = "";
                                    getOrderValue.ProductCode = "";
                                    getOrderValue.Productsno = "0";
                                    getOrderValue.Qty = 0;
                                    getOrderValue.Total = 0;
                                    getOrderValue.Desciption = "";
                                    getOrderValue.Units = "";
                                    getOrderValue.Unitqty = "";
                                    float Rate = 0;
                                    float TotalRate = 0;
                                    getOrderValue.Rate = (float)Rate;
                                    getOrderValue.orderunitRate = (float)TotalRate;
                                    getOrderValue.PrevQty = 0;
                                    getOrderValue.orderunitqty = "";
                                    OrderList.Add(getOrderValue);
                                    string respnceString = GetJson(OrderList);
                                    context.Response.Write(respnceString);
                                }
                            }
                        }
                        #endregion
                        if (DairyStatus == "Delivers")
                        {
                            cmd = new MySqlCommand("SELECT MAX(IndentNo) as IndentNo FROM indents where Branch_id = @bsno LIMIT 1");
                            cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                            DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                            string IndentNo = dtIndent.Rows[0]["IndentNo"].ToString();
                            string SalesType = context.Session["Salestype"].ToString();
                            if (SalesType == "Plant")
                            {
                                string RouteID = context.Request["RouteID"];
                                string DispDate = context.Session["DispDate"].ToString();
                                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                                //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status, indents_subtable.Cost as unitprice, productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno) AND (indents_subtable.Status <> 'Delivered') and (indents_subtable.Status <> 'Cancelled' ) AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                                cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType) group By productsdata.ProductName ORDER BY productsdata.Rank ");
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteId) AND (indents_subtable.Status <> 'Delivered') GROUP BY productsdata.ProductName, branchroutes.Sno");
                                //cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno ON dispatch_sub.dispatch_sno = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (indents_subtable.Status <> 'Delivered') AND (dispatch.sno = @dispatchsno)GROUP BY productsdata.ProductName");
                                cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.RouteName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType) GROUP BY productsdata.ProductName ORDER BY productsdata.Rank");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@dispatchsno", RouteID);
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtDailyIndent = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, branchproducts.manufact_remaining_qty as RemainQty FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchmappingtable.SuperBranch = @SuperBranch)  GROUP BY branchproducts.product_sno, productsdata.ProductName ");

                                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, ROUND(tripsubdata.Qty, 2) AS Qty FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.RouteID = @RouteID) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)");
                                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@EmpId", context.Session["UserSno"].ToString());
                                DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                                context.Session["Delivers"] = dtBranch;
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    int Branchprdtsno = 0;
                                    int.TryParse(dr["Product_sno"].ToString(), out Branchprdtsno);
                                    foreach (DataRow remainingdr in dtProducts.Rows)
                                    {
                                        int ProductId = 0;
                                        int.TryParse(remainingdr["ProductId"].ToString(), out ProductId);
                                        if (Branchprdtsno == ProductId)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.HdnSno = dr["Sno"].ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            //getOrderValue.Productsno = (int)dr["Product_sno"];
                                            float qty = 0;
                                            float.TryParse(dr["unitQty"].ToString(), out qty);
                                            getOrderValue.Qty = Math.Round(qty, 2);
                                            getOrderValue.Rate = (float)dr["UnitCost"];
                                            string LeakQty = dr["LeakQty"].ToString();
                                            float Dqty = 0;
                                            if (LeakQty != "")
                                            {
                                                float Leak = 0;
                                                float.TryParse(LeakQty, out Leak);
                                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                                                float.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                                                getOrderValue.DQty = Math.Round(Dqty, 2); ;

                                            }
                                            else
                                            {
                                                getOrderValue.LeakQty = 0;
                                                getOrderValue.DQty = Math.Round(qty, 2);
                                            }
                                            getOrderValue.Status = dr["Status"].ToString();
                                            float Rqty = 0;
                                            float.TryParse(remainingdr["Qty"].ToString(), out Rqty);
                                            //float.TryParse(dr["Qty"].ToString(), out Rqty);
                                            getOrderValue.RQty = Rqty;
                                            getOrderValue.Total = 0;
                                            foreach (DataRow drDaily in dtDailyIndent.Rows)
                                            {
                                                int ProSno = 0;
                                                int.TryParse(drDaily["Product_sno"].ToString(), out ProSno);
                                                if (ProSno == Branchprdtsno)
                                                {
                                                    float Iqty = 0;
                                                    float.TryParse(drDaily["Iqty"].ToString(), out Iqty);
                                                    float trqty = Iqty - Dqty; ;
                                                    getOrderValue.TRQty = Math.Round(trqty, 2);
                                                }
                                            }
                                            getOrderValue.orderunitRate = (float)dr["UnitCost"];
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                }
                            }
                            if (SalesType == "SALES OFFICE" || SalesType == "C & F")
                            {
                                string DispDate = context.Session["I_Date"].ToString();
                                DateTime dtdispDate = Convert.ToDateTime(DispDate);
                                //cmd = new MySqlCommand("SELECT indents.TotalQty,indents_subtable.Sno, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status, indents_subtable.Cost as unitprice, productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno) AND (indents_subtable.Status <> 'Delivered') and (indents_subtable.Status <> 'Cancelled' ) AND (indents.I_date > @d1) AND (indents.I_date < @d2) ");
                                cmd = new MySqlCommand("SELECT indents.I_date,indents_subtable.Sno,indents_subtable.LeakQty,indents_subtable.DeliveryQty, indents_subtable.unitQty,indents_subtable.UnitCost, indents_subtable.Product_sno, productsdata.ProductName, indents_subtable.Status,  productsdata.sno, indents.IndentNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @bsno)  AND (indents.I_date between @d1 AND  @d2) group By productsdata.ProductName ORDER BY productsdata.Rank ");
                                cmd.Parameters.Add("@UserName", Username);
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@bsno", context.Request["bid"].ToString());
                                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (branchroutes.Sno = @RouteId) AND (indents_subtable.Status <> 'Delivered') GROUP BY productsdata.ProductName, branchroutes.Sno");
                                //cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno ON dispatch_sub.dispatch_sno = branchroutes.Sno WHERE (indents.I_date > @d1) AND (indents.I_date < @d2) AND (indents_subtable.Status <> 'Delivered') AND (dispatch.sno = @dispatchsno)GROUP BY productsdata.ProductName");
                                cmd = new MySqlCommand(" SELECT SUM(indents_subtable.unitQty) AS Iqty, indents_subtable.Product_sno, productsdata.ProductName, branchroutes.RouteName FROM dispatch_sub INNER JOIN dispatch ON dispatch_sub.dispatch_sno = dispatch.sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN indents ON branchroutesubtable.BranchID = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (dispatch.sno = @dispatchsno) AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType=@IndentType ) GROUP BY productsdata.ProductName ORDER BY productsdata.Rank");
                                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(dtdispDate));
                                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(dtdispDate));
                                cmd.Parameters.Add("@dispatchsno", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@IndentType", IndentType);
                                DataTable dtDailyIndent = vdm.SelectQuery(cmd).Tables[0];
                                //cmd = new MySqlCommand("SELECT branchproducts.product_sno, productsdata.ProductName, branchproducts.manufact_remaining_qty as RemainQty FROM branchproducts INNER JOIN branchmappingtable ON branchproducts.branch_sno = branchmappingtable.SuperBranch INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchmappingtable.SuperBranch = @SuperBranch)  GROUP BY branchproducts.product_sno, productsdata.ProductName ");

                                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, ROUND(tripsubdata.Qty, 2) AS Qty FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE (triproutes.RouteID = @RouteID) AND (tripdata.Status = 'A') AND (tripdata.EmpId = @EmpId)");
                                cmd.Parameters.Add("@RouteID", context.Session["RouteId"].ToString());
                                cmd.Parameters.Add("@EmpId", context.Session["UserSno"].ToString());
                                DataTable dtProducts = vdm.SelectQuery(cmd).Tables[0];
                                context.Session["Delivers"] = dtBranch;
                                int i = 1;
                                foreach (DataRow dr in dtBranch.Rows)
                                {
                                    int Branchprdtsno = 0;
                                    int.TryParse(dr["Product_sno"].ToString(), out Branchprdtsno);
                                    foreach (DataRow remainingdr in dtProducts.Rows)
                                    {
                                        int ProductId = 0;
                                        int.TryParse(remainingdr["ProductId"].ToString(), out ProductId);
                                        if (Branchprdtsno == ProductId)
                                        {
                                            Orderclass getOrderValue = new Orderclass();
                                            getOrderValue.sno = i++.ToString();
                                            getOrderValue.HdnSno = dr["Sno"].ToString();
                                            getOrderValue.ProductCode = dr["ProductName"].ToString();
                                            getOrderValue.IndentNo = dr["IndentNo"].ToString();
                                            //getOrderValue.Productsno = (int)dr["Product_sno"];
                                            float qty = 0;
                                            float.TryParse(dr["unitQty"].ToString(), out qty);
                                            getOrderValue.Qty = Math.Round(qty, 2);

                                            getOrderValue.Rate = (float)dr["UnitCost"];
                                            string LeakQty = dr["LeakQty"].ToString();
                                            float Dqty = 0;
                                            if (LeakQty != "")
                                            {
                                                float Leak = 0;
                                                float.TryParse(LeakQty, out Leak);
                                                getOrderValue.LeakQty = Math.Round(Leak, 2);
                                                float.TryParse(dr["DeliveryQty"].ToString(), out Dqty);
                                                getOrderValue.DQty = Math.Round(Dqty, 2); ;
                                            }
                                            else
                                            {
                                                getOrderValue.LeakQty = 0;
                                                getOrderValue.DQty = Math.Round(qty, 2);
                                            }
                                            getOrderValue.Status = dr["Status"].ToString();
                                            float Rqty = 0;
                                            float.TryParse(remainingdr["Qty"].ToString(), out Rqty);
                                            //float.TryParse(dr["Qty"].ToString(), out Rqty);
                                            getOrderValue.RQty = Rqty;
                                            getOrderValue.Total = 0;
                                            foreach (DataRow drDaily in dtDailyIndent.Rows)
                                            {
                                                int ProSno = 0;
                                                int.TryParse(drDaily["Product_sno"].ToString(), out ProSno);
                                                if (ProSno == Branchprdtsno)
                                                {
                                                    float Iqty = 0;
                                                    float.TryParse(drDaily["Iqty"].ToString(), out Iqty);
                                                    float trqty = Iqty - Dqty; ;
                                                    getOrderValue.TRQty = Math.Round(trqty, 2);
                                                }
                                            }
                                            getOrderValue.orderunitRate = (float)dr["UnitCost"];
                                            OrderList.Add(getOrderValue);
                                        }
                                    }
                                }
                            }
                            string respnceString = GetJson(OrderList);
                            context.Response.Write(respnceString);
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void getOrderStatus(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string BranchID = context.Request["Bid"];
                string IndentType = context.Request["IndentType"];
                if (IndentType == "")
                {
                    IndentType = context.Session["IndentType"].ToString();
                }
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("select IndentNo from Indents where Branch_id=@Branch_id AND (indents.I_date between @d1 AND  @d2) and (indents.IndentType = @IndentType)");
                cmd.Parameters.Add("@Branch_id", BranchID);
                cmd.Parameters.Add("@IndentType", IndentType);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", DateConverter.GetHighDate(ServerDateCurrentdate));
                DataTable dtIndent = vdm.SelectQuery(cmd).Tables[0];
                if (dtIndent.Rows.Count > 0)
                {
                    string msg = "Indent Completed";
                    string errresponse = GetJson(msg);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        private void getTodayDate(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                string bid = context.Request["bid"];
                cmd = new MySqlCommand("select I_date from Indents where Branch_id=@Branch_id and indents.I_date > @d1");
                cmd.Parameters.Add("@Branch_id", bid);
                cmd.Parameters.Add("@d1", DateConverter.GetLowDate(ServerDateCurrentdate));
                DataTable indentDate = vdm.SelectQuery(cmd).Tables[0];
                DateTime date = (DateTime)indentDate.Rows[0]["I_date"];
                string IndentDate = date.ToString("dd/MM/yyyy");
                string Currentdate = "";// GetLowDate(vdm.conn).ToString("dd/MM/yyyy");
                if (IndentDate == Currentdate)
                {
                    string IDate = IndentDate;
                    string response = GetJson(IDate);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        private void GetRouteNameChange(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<Branch> brnch = new List<Branch>();
                string TripID = context.Request["TripId"];
                context.Session["TripID"] = TripID;
                string leveltype = context.Session["leveltype"].ToString();
                if (leveltype == "Agent")
                {

                    //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SuperBranch INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno WHERE (empmanage.Sno = @UserSno)");
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,branchdata.phonenumber FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchdata.sno = @sno) and (branchdata.flag=@flag)");
                    cmd.Parameters.Add("@flag", 1);
                    cmd.Parameters.Add("@sno", context.Session["branch"]);
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString(), mobile = dr["phonenumber"].ToString() };
                        brnch.Add(b);
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
                else
                {
                    //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM empmanage INNER JOIN branchmappingtable ON empmanage.Branch = branchmappingtable.SuperBranch INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno WHERE (empmanage.Sno = @UserSno)");
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,branchdata.phonenumber FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchroutes.Sno = @TripID) and (branchdata.flag=@flag)");
                    cmd.Parameters.Add("@TripID", TripID);
                    cmd.Parameters.Add("@flag", 1);
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        Branch b = new Branch() { b_id = dr["sno"].ToString(), BranchName = dr["BranchName"].ToString(), mobile = dr["phonenumber"].ToString() };
                        brnch.Add(b);
                    }
                    string response = GetJson(brnch);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }

        private void GetAgents(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteID = context.Request["RouteID"];
                cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName,branchroutes.Sno FROM branchroutesubtable INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchroutes.Sno = @RouteID)");
                //cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @BranchID)");
                cmd.Parameters.Add("@RouteID", RouteID);
                DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                List<SoClass> Agentslist = new List<SoClass>();
                foreach (DataRow dr in dtBranch.Rows)
                {
                    SoClass getAgent = new SoClass();
                    getAgent.Sno = dr["sno"].ToString();
                    getAgent.BranchName = dr["BranchName"].ToString();
                    getAgent.routeid = dr["Sno"].ToString();
                    Agentslist.Add(getAgent);
                }
                string response = GetJson(Agentslist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class IndentClas
        {
            public string IndentType { get; set; }
        }
        class Branch
        {
            public string b_id { set; get; }
            public string BranchName { set; get; }
            public string mobile { set; get; }
        }

        class SalelDetails
        {
            public string categoeryname { set; get; }
            public string productname { set; get; }
            public string value { set; get; }
            public string Deliverqty { set; get; }
            public string idate { set; get; }
            public string Rate { set; get; }
            public string LeakQty { set; get; }
            public string ReturnQty { set; get; }
            public string ShortQty { set; get; }
            public string NetQty { set; get; }
            public string productid { set; get; }
            public string Branchid { set; get; }
            public string BranchName { set; get; }
            public string salevalue { set; get; }
            public string produtandBranchid { set; get; }
            public string ddltype { set; get; }
            public string wbranchid { get; set; }
            public string type { get; set; }
            public string weekname { get; set; }
            public string fromdate { get; set; }
            public string todate { get; set; }
            public string month { get; set; }
            public string catid { get; set; }
            public string weeknumbers { get; set; }
            public List<weekcls> weeklist { get; set; }
        }
        public class weekcls
        {
            public string week { get; set; }
            public string status { get; set; }
        }

        private void GetmonthwiseSalevlue(HttpContext context)
        {
            DataTable Report = new DataTable();
            Report.Columns.Add("CategoeryName");
            Report.Columns.Add("ProductName");
            Report.Columns.Add("ProductId");
            Report.Columns.Add("Deliverqty");
            Report.Columns.Add("AvgQty");
            Report.Columns.Add("SaleValue");
            Report.Columns.Add("ReturnQty");
            Report.Columns.Add("ShortQty");
            Report.Columns.Add("IndentDate");
            Report.Columns.Add("catid");

            string month = context.Request["month"];
            string branchid = context.Request["branchid"];
            string fromdate = context.Request["fromdate"];
            string todate = context.Request["todate"];
            string categoryid = context.Request["categoryid"];

            var dt = DateTime.ParseExact(fromdate, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
            string FromDate = dt.ToString("yyyy-MM-dd");
            DateTime dtfromdate = Convert.ToDateTime(FromDate);

           
            var edt = DateTime.ParseExact(todate, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
            string Todate = edt.ToString("yyyy-MM-dd");
            DateTime dtenddate = Convert.ToDateTime(Todate);
            int year = dtfromdate.Year;
            int cmonth = Convert.ToInt32(month);
            int days =  DateTime.DaysInMonth(year, cmonth);
            int fromd = 01;

            string fdate = year + "-" + cmonth + "-" + fromd;
            dtfromdate = Convert.ToDateTime(fdate);
            string tdate = year + "-" + cmonth + "-" + days;
            DateTime dttodate = Convert.ToDateTime(tdate);
            try
            {
                DataTable dtsalevalue = new DataTable();
                cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                cmd.Parameters.Add("@Branchid", branchid);
                DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                string branchtype = "";
                if (dttable.Rows.Count > 0)
                {
                    branchtype = dttable.Rows[0]["salestype"].ToString();
                }
                if (branchid == "1")
                {
                    cmd = new MySqlCommand("SELECT  sno, BranchName, SalesType, flag, companycode FROM branchdata WHERE (companycode = @companycode) AND (SalesType = @SalesType) AND (flag <> 0)");
                    cmd.Parameters.Add("@companycode", branchid);
                    cmd.Parameters.Add("@SalesType", "23");
                    DataTable dtplats = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtAll = new DataTable();
                    DataTable dtsale_value = new DataTable();
                    DateTime dtF = dtfromdate;
                    TimeSpan dateSpan2 = dttodate.Subtract(dtF);
                    int NoOfdays = dateSpan2.Days;
                    string CategoeryName = "";
                    string ProductName = "";
                    string catid = "";

                    if (categoryid != "")
                    {
                        foreach (DataRow drplants in dtplats.Rows)
                        {
                            cmd = new MySqlCommand("SELECT  SUM(tripsubdata.Qty) AS Qty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue, products_category.sno AS catsno, products_category.Categoryname, productsdata.ProductName, productsdata.sno AS productid FROM  tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2) AND (products_category.sno = @catid) GROUP BY productsdata.sno");
                            cmd.Parameters.Add("@catid", categoryid);
                            cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                            cmd.Parameters.Add("@d1", GetLowDate(dtfromdate).AddDays(-1));
                            cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                            dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                            dtAll.Merge(dtsale_value);
                        }
                        //DataView view = new DataView(dtAll);
                        //DataTable distinctproducts = view.ToTable(true, "productid", "catsno", "Categoryname", "ProductName");
                        //DataView dv = distinctproducts.DefaultView;
                        //dv.Sort = "catsno";
                        //DataTable sortedProductDT = dv.ToTable();
                        DataView view = new DataView(dtAll);
                        DataTable distinctproducts = view.ToTable(true, "productid", "ProductName");
                        DataView dv = distinctproducts.DefaultView;
                        dv.Sort = "productid";
                        DataTable sortedProductDT = dv.ToTable();
                        foreach (DataRow drs in sortedProductDT.Rows)
                        {
                            double totalqty = 0; double totalsalevalue = 0;
                            foreach (DataRow drr in dtAll.Select("productid='" + drs["productid"].ToString() + "'"))
                            {
                                double qty = 0;
                                double.TryParse(drr["qty"].ToString(), out qty); ;
                                totalqty += qty;
                                double salevalue = 0;
                                CategoeryName = drr["Categoryname"].ToString();
                                ProductName = drr["ProductName"].ToString();
                                catid = drr["catsno"].ToString();
                                double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                totalsalevalue += salevalue;
                            }
                            DataRow newrow = Report.NewRow();
                            newrow["Deliverqty"] = totalqty;
                            newrow["SaleValue"] = totalsalevalue;
                            double avgqty = 0;
                            avgqty = totalqty / NoOfdays;
                            newrow["AvgQty"] = avgqty.ToString("F2");
                            if (categoryid != "")
                            {
                                newrow["ProductName"] = ProductName;
                            }
                            else
                            {
                                newrow["ProductName"] = CategoeryName;
                                newrow["catid"] = catid;
                            }
                            Report.Rows.Add(newrow);
                        }
                    }
                    else
                    {
                        foreach (DataRow drplants in dtplats.Rows)
                        {
                            cmd = new MySqlCommand("SELECT SUM(tripsubdata.Qty) AS Qty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue, products_category.sno AS catsno, products_category.Categoryname, productsdata.ProductName, productsdata.sno AS productid FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2) GROUP BY products_category.sno");
                            //cmd = new MySqlCommand("SELECT  TripInfo.tripid, ProductInfo.Categoryname,ProductInfo.catsno,ProductInfo.ProductName, SUM(ProductInfo.Qty) AS qty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, ProductInfo.productid FROM   (SELECT  tripdata.Sno AS tripid, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT UnitPrice,Categoryname, ProductName, Sno, Qty,catsno, productid FROM (SELECT        productsdata.UnitPrice,products_category.sno AS  catsno,products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty, productsdata.sno AS productid FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN  products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.tripid = ProductInfo.Sno GROUP BY ProductInfo.catsno");

                            cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                            cmd.Parameters.Add("@d1", GetLowDate(dtfromdate).AddDays(-1));
                            cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                            dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                            dtAll.Merge(dtsale_value);
                        }
                        //DataView view = new DataView(dtAll);
                        //DataTable distinctproducts = view.ToTable(true, "productid", "catsno", "Categoryname", "ProductName");
                        //DataView dv = distinctproducts.DefaultView;
                        //dv.Sort = "catsno";
                        //DataTable sortedProductDT = dv.ToTable();
                        DataView view1 = new DataView(dtAll);
                        DataTable distinctproducts1 = view1.ToTable(true, "catsno", "Categoryname");
                        DataView dv1 = distinctproducts1.DefaultView;
                        dv1.Sort = "catsno";
                        DataTable sortedProductDT1 = dv1.ToTable();
                        //DateTime dtF = dtfromdate;
                        //TimeSpan dateSpan2 = dttodate.Subtract(dtF);
                        //int NoOfdays = dateSpan2.Days;
                        //string CategoeryName = "";
                        //string ProductName = "";
                        //string catid = "";
                        foreach (DataRow drs in sortedProductDT1.Rows)
                        {
                            double totalqty = 0; double totalsalevalue = 0;
                            foreach (DataRow drr in dtAll.Select("catsno='" + drs["catsno"].ToString() + "'"))
                            {
                                double qty = 0;
                                double.TryParse(drr["qty"].ToString(), out qty); ;
                                totalqty += qty;
                                double salevalue = 0;
                                CategoeryName = drr["Categoryname"].ToString();
                                ProductName = drr["ProductName"].ToString();
                                catid = drr["catsno"].ToString();
                                double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                totalsalevalue += salevalue;
                            }
                            DataRow newrow = Report.NewRow();
                            newrow["Deliverqty"] = totalqty;
                            newrow["SaleValue"] = totalsalevalue;
                            double avgqty = 0;
                            avgqty = totalqty / NoOfdays;
                            newrow["AvgQty"] = avgqty.ToString("F2");
                            if (categoryid != "")
                            {
                                newrow["ProductName"] = ProductName;
                            }
                            else
                            {
                                newrow["ProductName"] = CategoeryName;
                                newrow["catid"] = catid;
                            }
                            Report.Rows.Add(newrow);
                        }
                    }
                }
                else if (branchtype == "Plant")
                {
                    if (categoryid != "")
                    {
                        cmd = new MySqlCommand("SELECT   SUM(tripsubdata.Qty) AS DeliveryQty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue, products_category.sno AS catsno, products_category.Categoryname, productsdata.ProductName, productsdata.sno AS productid FROM  tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2) AND (products_category.sno = @catid) GROUP BY productsdata.sno");
                        cmd.Parameters.Add("@catid", categoryid);
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT SUM(tripsubdata.Qty) AS DeliveryQty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue, products_category.sno AS catsno, products_category.Categoryname, productsdata.ProductName, productsdata.sno AS productid FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2) GROUP BY products_category.sno");
                        //cmd = new MySqlCommand("SELECT  TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname, ProductInfo.catsno, ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno FROM  (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT  Categoryname, ProductName,UnitPrice, Sno, Qty, CatSno,productid FROM   (SELECT  productsdata.UnitPrice,productsdata.sno AS productid,products_category.sno AS catsno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM   tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE   (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno GROUP BY ProductInfo.catsno");
                    }
                    cmd.Parameters.Add("@branch", branchid);
                    //cmd.Parameters.Add("@SOID", branchid);
                    cmd.Parameters.Add("@d1", GetLowDate(dtfromdate).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                    dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    if (categoryid != "")
                    {
                        cmd = new MySqlCommand("SELECT  ROUND(indents_subtable.UnitCost, 2) AS cost, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, products_category.Categoryname, productsdata.ProductName,  productsdata.sno AS productid, products_category.sno AS catsno  FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN branchmappingtable ON indents.Branch_id = branchmappingtable.SubBranch WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchmappingtable.SuperBranch = @brnchid) AND (products_category.sno = @catid) GROUP BY  productsdata.sno");
                        cmd.Parameters.Add("@catid", categoryid);
                    }
                    else
                    {
                        //cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue,products_category.Categoryname, productsdata.ProductName,  productsdata.sno AS productid, products_category.sno AS catsno FROM  branchmappingtable INNER JOIN indents ON branchmappingtable.SubBranch = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE  (branchmappingtable.SuperBranch = @BranchID) AND (indents.I_date BETWEEN @d1 AND @d2) GROUP BY  products_category.sno");
                        cmd = new MySqlCommand("SELECT  ROUND(indents_subtable.UnitCost, 2) AS cost, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, products_category.Categoryname, productsdata.ProductName,  productsdata.sno AS productid, products_category.sno AS catsno  FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN branchmappingtable ON indents.Branch_id = branchmappingtable.SubBranch WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchmappingtable.SuperBranch = @brnchid) GROUP BY  products_category.sno");
                    }
                    DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                    cmd.Parameters.Add("@brnchid", branchid);
                    cmd.Parameters.Add("@d1", GetLowDate(dtfromdate).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                    dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                }
                foreach (DataRow drsv in dtsalevalue.Rows)
                {
                    DataRow newrow = Report.NewRow();
                    newrow["Deliverqty"] = drsv["DeliveryQty"].ToString();
                    newrow["SaleValue"] = drsv["salevalue"].ToString();
                    if (categoryid != "")
                    {
                        newrow["ProductName"] = drsv["ProductName"].ToString();
                    }
                    else
                    {
                        newrow["ProductName"] = drsv["Categoryname"].ToString();
                    }
                    newrow["catid"] = drsv["catsno"].ToString();
                    TimeSpan dateSpan = dttodate.Subtract(dtfromdate);
                    double dayss = dateSpan.TotalDays;
                    double delQty = 0;
                    double.TryParse(drsv["DeliveryQty"].ToString(), out delQty);
                    double qty = 0;
                    qty = delQty / days;
                    newrow["AvgQty"] = qty.ToString("f2");
                    Report.Rows.Add(newrow);
                }
                List<SalelDetails> SalelDetailslist1 = new List<SalelDetails>();
                foreach (DataRow drsale in Report.Rows)
                {
                    float qty = 0; float lqty = 0; float rqty = 0; float sqty = 0; float dqty = 0;
                    float netqty = 0;
                    SalelDetails getsalevaluedetails = new SalelDetails();
                    float.TryParse(drsale["Deliverqty"].ToString(), out dqty);
                    float.TryParse(drsale["AvgQty"].ToString(), out lqty);
                    float lsqty = lqty + sqty;
                    float drqty = rqty + dqty;
                    netqty = drqty - lsqty;
                    getsalevaluedetails.Deliverqty = dqty.ToString();
                    getsalevaluedetails.LeakQty = lqty.ToString();
                    getsalevaluedetails.ReturnQty = rqty.ToString();
                    getsalevaluedetails.idate = drsale["IndentDate"].ToString();
                    getsalevaluedetails.salevalue = drsale["SaleValue"].ToString();
                    getsalevaluedetails.NetQty = netqty.ToString();
                    getsalevaluedetails.ddltype = "Weeks";
                    getsalevaluedetails.productname = drsale["ProductName"].ToString();
                    getsalevaluedetails.catid = drsale["catid"].ToString();
                    SalelDetailslist1.Add(getsalevaluedetails);
                }
                string response = GetJson(SalelDetailslist1);
                context.Response.Write(response);
            }
            catch
            {
            }
        }

        private void GetSalevlue(HttpContext context)
        {
            try
            {
                //
                vdm = new VehicleDBMgr();
                DataTable Report = new DataTable();
                Report.Columns.Add("CategoeryName");
                Report.Columns.Add("ProductName");
                Report.Columns.Add("ProductId");
                Report.Columns.Add("Deliverqty");
                Report.Columns.Add("AvgQty");
                Report.Columns.Add("SaleValue");
                Report.Columns.Add("ReturnQty");
                Report.Columns.Add("ShortQty");
                Report.Columns.Add("IndentDate");
                Report.Columns.Add("Month");
                string IndentType = context.Request["IndentType"];
                string s = context.Request["startDate"];
                var dt = DateTime.ParseExact(s, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string FromDate = dt.ToString("yyyy-MM-dd");
                DateTime From_Date = Convert.ToDateTime(FromDate);
                string e = context.Request["endDate"];
                var edt = DateTime.ParseExact(e, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string Todate = edt.ToString("yyyy-MM-dd");
                DateTime Enddate = Convert.ToDateTime(Todate);
                int Ndays = (Enddate - From_Date).Days;
                int countdays = Ndays + 1;
                string type = "";
                if (countdays <= 7)
                {
                    type = "Daily";
                }
                else if (countdays <= 30 || countdays <= 8)
                {
                    type = "Weekly";
                }
                else
                {
                    type = "Monthly";
                }

                string branchid = context.Request["branchname"];
                IndentType = "Indent1";
                DataTable dtsalevalue = new DataTable();
                DataTable dtlekages = new DataTable();
                cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                cmd.Parameters.Add("@Branchid", branchid);
                DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                string branchtype = "";
                if (dttable.Rows.Count > 0)
                {
                    branchtype = dttable.Rows[0]["salestype"].ToString();
                }
                if (branchid == "1")
                {

                    cmd = new MySqlCommand("SELECT  sno, BranchName, SalesType, flag, companycode FROM branchdata WHERE        (companycode = @companycode) AND (SalesType = @SalesType) AND (flag <> 0)");
                    cmd.Parameters.Add("@companycode", branchid);
                    cmd.Parameters.Add("@SalesType", "23");
                    DataTable dtplats = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtAll = new DataTable();
                    if (type == "Daily")
                    {
                        foreach (DataRow drplants in dtplats.Rows)
                        {
                            cmd = new MySqlCommand("SELECT  TripInfo.tripid, ProductInfo.Categoryname,ProductInfo.catsno,ProductInfo.ProductName, SUM(ProductInfo.Qty) AS qty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, ProductInfo.productid FROM   (SELECT  tripdata.Sno AS tripid, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT UnitPrice,Categoryname, ProductName, Sno, Qty,catsno, productid FROM (SELECT        productsdata.UnitPrice,products_category.sno AS  catsno,products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty, productsdata.sno AS productid FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN  products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.tripid = ProductInfo.Sno GROUP BY ProductInfo.productid order by ProductInfo.Categoryname,ProductInfo.productid");
                            cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                            cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                            cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                            DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                            dtAll.Merge(dtsale_value);
                        }
                        DataView view = new DataView(dtAll);
                        DataTable distinctproducts = view.ToTable(true, "productid", "catsno", "Categoryname");
                        DataView dv = distinctproducts.DefaultView;
                        dv.Sort = "catsno";
                        DataTable sortedProductDT = dv.ToTable();
                        DateTime dtF = From_Date.AddDays(-1);
                        TimeSpan dateSpan2 = Enddate.Subtract(dtF);
                        int NoOfdays = dateSpan2.Days;
                        string ProductName = "";
                        string CategoeryName = "";
                        string Itemcode = "";
                        string actual = "";
                        foreach (DataRow dr in sortedProductDT.Rows)
                        {
                            //Strat this is For showing The categoryname in  ProductColumn
                            DataRow newrowcategory = Report.NewRow();
                            if (actual == dr["Categoryname"].ToString())
                            {
                                
                            }
                            else
                            {
                                newrowcategory["ProductId"] = dr["catsno"].ToString();
                                newrowcategory["CategoeryName"] = dr["Categoryname"].ToString();
                                newrowcategory["ProductName"] = dr["Categoryname"].ToString();
                                Report.Rows.Add(newrowcategory);
                                actual = dr["Categoryname"].ToString();
                            }//End
                            double totalqty = 0; double totalsalevalue = 0;
                            foreach (DataRow drr in dtAll.Select("productid='" + dr["productid"].ToString() + "'"))
                            {
                                double qty = 0;
                                double.TryParse(drr["qty"].ToString(), out qty); ;
                                CategoeryName = drr["Categoryname"].ToString();
                                ProductName = drr["ProductName"].ToString();
                                Itemcode = drr["productid"].ToString();
                                totalqty += qty;
                                double salevalue = 0;
                                double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                totalsalevalue += salevalue;
                            }

                            DataRow newrow = Report.NewRow();
                            newrow["Deliverqty"] = totalqty;
                            newrow["SaleValue"] = totalsalevalue;
                            double avgqty = 0;
                            avgqty = totalqty / NoOfdays;
                            newrow["AvgQty"] = avgqty.ToString("F2");
                            newrow["ProductName"] = ProductName;
                            newrow["ProductId"] = Itemcode;
                            newrow["CategoeryName"] = CategoeryName;
                            Report.Rows.Add(newrow);
                        }
                    }
                    if (type == "Weekly")
                    {
                        string strfromdate = From_Date.ToString();
                        DateTime fromDate = DateTime.Parse(strfromdate.Trim());
                        var d_fromdate = fromDate;
                        CultureInfo cul_from = CultureInfo.CurrentCulture;
                        int from_weekNum = cul_from.Calendar.GetWeekOfYear(
                            d_fromdate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);

                        string strtodate = Enddate.ToString();
                        DateTime toDate = DateTime.Parse(strtodate.Trim());
                        var d_toDate = toDate;
                        CultureInfo cul_to = CultureInfo.CurrentCulture;
                        int to_weekNum = cul_to.Calendar.GetWeekOfYear(
                            d_toDate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);
                        int diffweeks = to_weekNum - from_weekNum;
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            int newweek = from_weekNum;
                            for (int j = 0; j < diffweeks; j++)
                            {
                                firstmonth = GetLowDate(From_Date);
                                lastmonth = GetHighDate(firstmonth.AddDays(7));
                                dtAll = new DataTable();
                                foreach (DataRow drplants in dtplats.Rows)
                                {
                                    cmd = new MySqlCommand("SELECT   SUM(tripsubdata.Qty) AS qty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                                    cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                                    cmd.Parameters.Add("@SOID", drplants["sno"].ToString());
                                    DateTime dtF = firstmonth;
                                    cmd.Parameters.Add("@d1", dtF);
                                    cmd.Parameters.Add("@d2", lastmonth);
                                    DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                                    dtAll.Merge(dtsale_value);
                                }
                                //string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                //string Changedt = firstmonth.ToString("MMM");

                                string ChangedTime1 = firstmonth.ToString("dd/MMM");
                                string ChangedTime2 = lastmonth.ToString("dd/MMM");

                                string Changedt = firstmonth.ToString("MMM");
                                string mnth = firstmonth.ToString("MM");
                                DataView view = new DataView(dtAll);
                                double totalqty = 0; double totalsalevalue = 0;
                                foreach (DataRow drr in dtAll.Rows)
                                {
                                    double qty = 0;
                                    double.TryParse(drr["qty"].ToString(), out qty); ;
                                    totalqty += qty;
                                    double salevalue = 0;
                                    double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                    totalsalevalue += salevalue;

                                }
                                DataRow newrow = Report.NewRow();
                                newrow["Deliverqty"] = totalqty.ToString("F2");
                                newrow["SaleValue"] = totalsalevalue.ToString("F2");
                                //newrow["ProductName"] = "" + ChangedTime1 + "__" + ChangedTime2 + "";
                                newrow["ProductName"] = "W" + newweek + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                double avgqty = 0;
                                avgqty = totalqty / 7;
                                newrow["AvgQty"] = avgqty.ToString("F2");
                                newrow["Month"] = mnth;
                                Report.Rows.Add(newrow);
                                newweek = newweek + 1;
                                From_Date = From_Date.AddDays(7);
                            }
                        }
                    }
                    if (type == "Monthly")
                    {
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;

                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                double totalqty = 0; double totalsalevalue = 0;
                                firstmonth = GetLowMonthRetrive(From_Date.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                string mnth = firstmonth.ToString("MM");
                                int NoOfdays = 0;
                                dtAll = new DataTable();
                                foreach (DataRow drplants in dtplats.Rows)
                                {
                                    cmd = new MySqlCommand("SELECT   SUM(tripsubdata.Qty) AS Qty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                                    cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                                    cmd.Parameters.Add("@SOID", drplants["sno"].ToString());
                                    DateTime dtF = firstmonth.AddDays(-1);
                                    cmd.Parameters.Add("@d1", dtF);
                                    cmd.Parameters.Add("@d2", lastmonth);
                                    DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                                    TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                    NoOfdays = dateSpan2.Days;
                                    dtAll.Merge(dtsale_value);
                                }
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                //DataView view = new DataView(dtAll);
                                //DataTable distinctproducts = view.ToTable(true, "productid");
                                string ProductName = "";
                                string Itemcode = "";
                                foreach (DataRow dr in dtAll.Rows)
                                {
                                    double qty = 0;
                                    double.TryParse(dr["Qty"].ToString(), out qty); ;
                                    totalqty += qty;
                                    double salevalue = 0;
                                    double.TryParse(dr["salevalue"].ToString(), out salevalue); ;
                                    totalsalevalue += salevalue;

                                }
                                DataRow newrow = Report.NewRow();
                                double avgqty = 0;
                                avgqty = totalqty / NoOfdays;
                                newrow["Deliverqty"] = totalqty;
                                newrow["SaleValue"] = totalsalevalue.ToString("F2");
                                newrow["ProductName"] = Changedt;
                                newrow["AvgQty"] = avgqty.ToString("F2");
                                newrow["Month"] = mnth;
                                Report.Rows.Add(newrow);
                            }
                        }
                    }
                }
                else if (branchtype == "Plant")
                {
                    if (type == "Daily")
                    {
                        // cmd = new MySqlCommand("SELECT TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname, SUM(ProductInfo.Qty) AS DeliveryQty, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode FROM (SELECT        tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE  (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT Categoryname, ProductName, Sno, Qty FROM (SELECT products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno GROUP BY ProductInfo.ProductName");
                        cmd = new MySqlCommand("SELECT  TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname,ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno FROM  (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT  Categoryname, ProductName,UnitPrice, Sno, Qty, CatSno,productid FROM   (SELECT  productsdata.UnitPrice,productsdata.sno AS productid,products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM   tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE   (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno GROUP BY ProductInfo.ProductName ORDER BY ProductInfo.CatSno, ProductInfo.ProductName");
                        cmd.Parameters.Add("@branch", branchid);
                        cmd.Parameters.Add("@SOID", branchid);
                        cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                        cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                        // DataTable dtble = vdm.SelectQuery(cmd).Tables[0];
                        dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (type == "Weekly")
                    {
                        string strfromdate = From_Date.ToString();
                        DateTime fromDate = DateTime.Parse(strfromdate.Trim());
                        var d_fromdate = fromDate;
                        CultureInfo cul_from = CultureInfo.CurrentCulture;
                        int from_weekNum = cul_from.Calendar.GetWeekOfYear(
                            d_fromdate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);
                        string strtodate = Enddate.ToString();
                        DateTime toDate = DateTime.Parse(strtodate.Trim());
                        var d_toDate = toDate;
                        CultureInfo cul_to = CultureInfo.CurrentCulture;
                        int to_weekNum = cul_to.Calendar.GetWeekOfYear(
                            d_toDate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);
                        int diffweeks = to_weekNum - from_weekNum;
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            int newweek = from_weekNum;
                            for (int j = 0; j < diffweeks; j++)
                            {
                                firstmonth = GetLowDate(From_Date);
                                lastmonth = GetHighDate(firstmonth.AddDays(7));
                                cmd = new MySqlCommand("SELECT   SUM(tripsubdata.Qty) AS DeliveryQty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                                //   cmd = new MySqlCommand("SELECT TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname, SUM(ProductInfo.Qty) AS DeliveryQty, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno FROM (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT Categoryname, ProductName, Sno, Qty, CatSno FROM (SELECT        products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno ORDER BY ProductInfo.CatSno");
                                cmd.Parameters.Add("@branch", branchid);
                                cmd.Parameters.Add("@SOID", branchid);
                                DateTime dtF = firstmonth;
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("dd/MMM");
                                string ChangedTime2 = lastmonth.ToString("dd/MMM");
                                string Changedt = firstmonth.ToString("MMM");
                                string mnth = firstmonth.ToString("MM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    //newrow["ProductName"] = "" + ChangedTime1 + "__" + ChangedTime2 + "";
                                    newrow["ProductName"] = "W" + newweek + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);

                                    double qty = 0;
                                    qty = delQty / 7;
                                    newrow["Deliverqty"] = delQty.ToString("F2");
                                    newrow["AvgQty"] = qty.ToString("F2");


                                    double salevalue = 0;
                                    double.TryParse(dr["salevalue"].ToString(), out salevalue); ;
                                    newrow["SaleValue"] = salevalue.ToString("F2");
                                    newrow["Month"] = mnth;


                                    Report.Rows.Add(newrow);
                                }
                                newweek = newweek + 1;
                                From_Date = From_Date.AddDays(7);
                            }
                        }
                    }
                    if (type == "Monthly")
                    {
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(From_Date.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT   SUM(tripsubdata.Qty) AS DeliveryQty, SUM(productsdata.UnitPrice * tripsubdata.Qty) AS salevalue FROM tripdata INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno WHERE  (tripdata.BranchID = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)");
                                // cmd = new MySqlCommand("SELECT TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname, SUM(ProductInfo.Qty) AS DeliveryQty, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode FROM (SELECT        tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE  (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT Categoryname, ProductName, Sno, Qty FROM (SELECT products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno ");
                                //  cmd = new MySqlCommand("SELECT TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname, SUM(ProductInfo.Qty) AS DeliveryQty, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType,TripInfo.DispMode, ProductInfo.CatSno FROM (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE        (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT Categoryname, ProductName, Sno, Qty, CatSno FROM (SELECT products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno ORDER BY ProductInfo.CatSno");
                                cmd.Parameters.Add("@branch", branchid);
                                cmd.Parameters.Add("@SOID", branchid);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                string mnth = firstmonth.ToString("MM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["ProductName"] = Changedt;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    double qty = 0;
                                    qty = delQty / NoOfdays;
                                    newrow["Deliverqty"] = delQty.ToString("F2");
                                    newrow["AvgQty"] = qty.ToString("F2");

                                    double salevalue = 0;
                                    double.TryParse(dr["salevalue"].ToString(), out salevalue); ;
                                    newrow["SaleValue"] = salevalue.ToString("F2");
                                    newrow["Month"] = mnth;
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //cmd = new MySqlCommand("SELECT  tripdat.Sno, tripdat.I_Date, leakages.TotalLeaks AS LeakQty, productsdata.UnitPrice, productsdata.ProductName, leakages.ProductID, leakages.LeakQty, leakages.TripID,leakages.VarifyStatus, leakages.ShortQty, leakages.ReturnQty AS ReturnQty FROM dispatch INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN (SELECT Sno, AssignDate, I_Date FROM tripdata WHERE (I_Date BETWEEN @d1 AND @d2)) tripdat ON triproutes.Tripdata_sno = tripdat.Sno INNER JOIN leakages ON tripdat.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno WHERE (dispatch.BranchID = @branchid)");
                    //cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    //cmd.Parameters.Add("@d2", GetHighDate(To_date).AddDays(-1));
                    //cmd.Parameters.Add("@BranchID", branchid);
                    //dtlekages = vdm.SelectQuery(cmd).Tables[0];
                    if (type == "Daily")
                    {
                        cmd = new MySqlCommand("SELECT  ROUND(indents_subtable.UnitCost, 2) AS cost, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, products_category.Categoryname, productsdata.ProductName,  productsdata.sno AS productid, products_category.sno AS catsno  FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN branchmappingtable ON indents.Branch_id = branchmappingtable.SubBranch WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchmappingtable.SuperBranch = @brnchid) GROUP BY  products_category.Categoryname,productsdata.sno, products_category.sno order by products_category.sno,productsdata.sno");
                        DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                        cmd.Parameters.Add("@brnchid", branchid);
                        cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                        cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                        dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (type == "Weekly")
                    {
                        string strfromdate = From_Date.ToString();
                        DateTime fromDate = DateTime.Parse(strfromdate.Trim());
                        var d_fromdate = fromDate;
                        CultureInfo cul_from = CultureInfo.CurrentCulture;
                        int from_weekNum = cul_from.Calendar.GetWeekOfYear(
                            d_fromdate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);

                        string strtodate = Enddate.ToString();
                        DateTime toDate = DateTime.Parse(strtodate.Trim());
                        var d_toDate = toDate;
                        CultureInfo cul_to = CultureInfo.CurrentCulture;
                        int to_weekNum = cul_to.Calendar.GetWeekOfYear(
                            d_toDate,
                            CalendarWeekRule.FirstDay,
                            DayOfWeek.Monday);
                        int diffweeks = to_weekNum - from_weekNum;
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            int newweek = from_weekNum;
                            for (int j = 0; j < diffweeks; j++)
                            {
                                firstmonth = GetLowDate(From_Date);
                                lastmonth = GetHighDate(firstmonth.AddDays(7));

                                cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue FROM  branchmappingtable INNER JOIN indents ON branchmappingtable.SubBranch = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE  (branchmappingtable.SuperBranch = @BranchID) AND (indents.I_date BETWEEN @d1 AND @d2)");
                                //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(DeliveryQty * UnitCost), 2) AS salevalue, indents.I_date FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchroutes.BranchID = @BranchID) GROUP BY branchroutes.BranchID");
                                cmd.Parameters.Add("@BranchID", branchid);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("dd/MMM");
                                string ChangedTime2 = lastmonth.ToString("dd/MMM");
                                string mnth = firstmonth.ToString("MM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    //newrow["ProductName"] = "" + ChangedTime1 + "_" + ChangedTime2 + "";
                                    newrow["ProductName"] = "W" + newweek + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    double qty = 0;
                                    qty = delQty / 7;
                                    newrow["Deliverqty"] = delQty.ToString("F2");
                                    newrow["AvgQty"] = qty.ToString("F2");
                                    double salevalue = 0;
                                    double.TryParse(dr["salevalue"].ToString(), out salevalue); ;
                                    newrow["SaleValue"] = salevalue.ToString("F2");
                                    newrow["Month"] = mnth;
                                    Report.Rows.Add(newrow);
                                }
                                newweek = newweek + 1;
                                From_Date = From_Date.AddDays(7);
                            }
                        }
                    }
                    if (type == "Monthly")
                    {
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(From_Date);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(From_Date.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue FROM  branchmappingtable INNER JOIN indents ON branchmappingtable.SubBranch = indents.Branch_id INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo WHERE  (branchmappingtable.SuperBranch = @BranchID) AND (indents.I_date BETWEEN @d1 AND @d2)");
                                //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(DeliveryQty * UnitCost), 2) AS salevalue, indents.I_date FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchroutes.BranchID = @BranchID) GROUP BY branchroutes.BranchID");
                                cmd.Parameters.Add("@BranchID", branchid);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                string mnth = firstmonth.ToString("MM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["ProductName"] = Changedt;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    double qty = 0;
                                    qty = delQty / NoOfdays;
                                    newrow["Deliverqty"] = delQty.ToString("F2");
                                    newrow["AvgQty"] = qty.ToString("F2");
                                    double salevalue = 0;
                                    double.TryParse(dr["salevalue"].ToString(), out salevalue); ;
                                    newrow["SaleValue"] = salevalue.ToString("F2");
                                    newrow["Month"] = mnth;
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                }
                List<SalelDetails> SalelDetailslist1 = new List<SalelDetails>();
                //if (Report.Rows.Count > 0)
                //{
                Enddate = Enddate.AddDays(1); ;
                string temp = "";
                int title = 0;
                foreach (DataRow dr in dtsalevalue.Rows)
                {
                    //Strat this is For showing The categoryname in  ProductColumn
                    DataRow newrowcategory = Report.NewRow();
                    if (temp == dr["Categoryname"].ToString())
                    {
                        //title = 0;
                    }
                    else
                    {
                        newrowcategory["ProductId"] = dr["catsno"].ToString();
                        newrowcategory["CategoeryName"] = dr["Categoryname"].ToString();
                        newrowcategory["ProductName"] = dr["Categoryname"].ToString();
                        Report.Rows.Add(newrowcategory);
                        temp = dr["Categoryname"].ToString();
                        title = 1;

                    }
                    //End
                    //if (title == 0)
                    //{
                    DataRow newrow = Report.NewRow();
                    newrow["CategoeryName"] = dr["Categoryname"].ToString();
                    newrow["Deliverqty"] = dr["DeliveryQty"].ToString();
                    newrow["ProductName"] = dr["ProductName"].ToString();
                    newrow["ProductId"] = dr["productid"].ToString();
                    newrow["SaleValue"] = dr["salevalue"].ToString();
                    TimeSpan dateSpan = Enddate.Subtract(From_Date);
                    double days = dateSpan.TotalDays;
                    double delQty = 0;
                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                    double qty = 0;
                    qty = delQty / days;
                    newrow["AvgQty"] = qty.ToString("f2");
                    Report.Rows.Add(newrow);
                    //}
                }
                foreach (DataRow drsale in Report.Rows)
                {
                    float qty = 0; float lqty = 0; float rqty = 0; float sqty = 0; float dqty = 0;
                    float netqty = 0;
                    SalelDetails getsalevaluedetails = new SalelDetails();
                    float.TryParse(drsale["Deliverqty"].ToString(), out dqty);
                    float.TryParse(drsale["AvgQty"].ToString(), out lqty);
                    float lsqty = lqty + sqty;
                    float drqty = rqty + dqty;
                    netqty = drqty - lsqty;
                    getsalevaluedetails.Deliverqty = dqty.ToString();
                    getsalevaluedetails.LeakQty = lqty.ToString();
                    getsalevaluedetails.categoeryname = drsale["categoeryname"].ToString();
                    getsalevaluedetails.productname = drsale["ProductName"].ToString();
                    getsalevaluedetails.productid = drsale["ProductId"].ToString();
                    getsalevaluedetails.ReturnQty = rqty.ToString();
                    getsalevaluedetails.idate = drsale["IndentDate"].ToString();
                    getsalevaluedetails.salevalue = drsale["SaleValue"].ToString();
                    getsalevaluedetails.NetQty = netqty.ToString();
                    getsalevaluedetails.ddltype = type;
                    getsalevaluedetails.month = drsale["Month"].ToString();
                    getsalevaluedetails.fromdate = From_Date.ToString();
                    getsalevaluedetails.todate = Enddate.ToString();
                    SalelDetailslist1.Add(getsalevaluedetails);
                }
                string response = GetJson(SalelDetailslist1);
                context.Response.Write(response); 
                //}
            }
            catch (Exception ex)
            {
                string Response = GetJson(ex.Message);
                context.Response.Write(Response);
            }
        }

        private void getcheckboxweekdates(HttpContext context)
        {
            try
            {
                DBManager dbm = new DBManager();
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                int year = ServerDateCurrentdate.Year;
                List<SalelDetails> weekslist = new List<SalelDetails>();
                for (var i = 1; i < 53; i++)
                {
                    //string weekid = es.week;
                    SqlCommand cmdd = new SqlCommand("SELECT  DATEADD(wk, DATEDIFF(wk, 6, CAST(RTRIM(@year * 10000 + 1 * 100 + 1) AS DATETIME)) + (@week - 1), 6) AS start_of_week, DATEADD(second, - 1, DATEADD(day, DATEDIFF(day, 0, DATEADD(wk, DATEDIFF(wk, 5, CAST(RTRIM(@year * 10000 + 1 * 100 + 1) AS DATETIME)) + (@week + - 1), 5)) + 1, 0)) AS end_of_week");
                    cmdd.Parameters.Add("@year", year);
                    cmdd.Parameters.Add("@week", i);
                    DataTable dtemp = dbm.SelectQuery(cmdd).Tables[0];
                    string fromdate = dtemp.Rows[0]["start_of_week"].ToString();//dr["start_of_week"].ToString();
                    string todate = dtemp.Rows[0]["end_of_week"].ToString();//dr["end_of_week"].ToString();
                    DateTime dtfromdate = Convert.ToDateTime(fromdate);
                    DateTime dttodate = Convert.ToDateTime(todate);
                    string ChangedTime1 = dtfromdate.ToString("dd/MMM");
                    string ChangedTime2 = dttodate.ToString("dd/MMM");
                    string week = "" + i + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                    SalelDetails obj = new SalelDetails();
                    obj.weekname = "" + week;
                    obj.weeknumbers = i.ToString();
                    weekslist.Add(obj);
                }
                string response = GetJson(weekslist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetweekwiseSalevlue(string jsonString, HttpContext context)
        {
            try
            {
                var js = new JavaScriptSerializer();
                DataTable Report = new DataTable();
                Report.Columns.Add("CategoeryName");
                Report.Columns.Add("ProductName");
                Report.Columns.Add("ProductId");
                Report.Columns.Add("Deliverqty");
                Report.Columns.Add("AvgQty");
                Report.Columns.Add("SaleValue");
                Report.Columns.Add("ReturnQty");
                Report.Columns.Add("ShortQty");
                Report.Columns.Add("IndentDate");
                Report.Columns.Add("Week");
                vdm = new VehicleDBMgr();
                DBManager dbm = new DBManager();
                DataTable dtsalevalue = new DataTable();
                var title1 = context.Request.Params[1];
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                int year = ServerDateCurrentdate.Year;
                SalelDetails obj = js.Deserialize<SalelDetails>(jsonString);
                string branchid = obj.wbranchid.Trim();
                string type = obj.type;
                cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                cmd.Parameters.Add("@Branchid", branchid);
                DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                string branchtype = "";
                if (dttable.Rows.Count > 0)
                {
                    branchtype = dttable.Rows[0]["salestype"].ToString();
                }
                foreach (weekcls es in obj.weeklist)
                {
                    string weekid = es.week;
                    SqlCommand cmdd = new SqlCommand("SELECT  DATEADD(wk, DATEDIFF(wk, 6, CAST(RTRIM(@year * 10000 + 1 * 100 + 1) AS DATETIME)) + (@week - 1), 6) AS start_of_week, DATEADD(second, - 1, DATEADD(day, DATEDIFF(day, 0, DATEADD(wk, DATEDIFF(wk, 5, CAST(RTRIM(@year * 10000 + 1 * 100 + 1) AS DATETIME)) + (@week + - 1), 5)) + 1, 0)) AS end_of_week");
                    cmdd.Parameters.Add("@year", year);
                    cmdd.Parameters.Add("@week", weekid);
                    DataTable dtemp = dbm.SelectQuery(cmdd).Tables[0];
                    if (dtemp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtemp.Rows)
                        {
                            string fromdate = dr["start_of_week"].ToString();
                            string todate = dr["end_of_week"].ToString();
                            DateTime dtfromdate = Convert.ToDateTime(fromdate);
                            DateTime dttodate = Convert.ToDateTime(todate);
                            string ChangedTime1 = dtfromdate.ToString("dd/MMM");
                            string ChangedTime2 = dttodate.ToString("dd/MMM");
                            if (branchid == "1")
                            {
                                cmd = new MySqlCommand("SELECT  sno, BranchName, SalesType, flag, companycode FROM branchdata WHERE (companycode = @companycode) AND (SalesType = @SalesType) AND (flag <> 0)");
                                cmd.Parameters.Add("@companycode", branchid);
                                cmd.Parameters.Add("@SalesType", "23");
                                DataTable dtplats = vdm.SelectQuery(cmd).Tables[0];
                                DataTable dtAll = new DataTable();
                                foreach (DataRow drplants in dtplats.Rows)
                                {
                                    cmd = new MySqlCommand("SELECT  TripInfo.tripid, ProductInfo.Categoryname,ProductInfo.catsno,ProductInfo.ProductName, SUM(ProductInfo.Qty) AS qty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, ProductInfo.productid FROM   (SELECT  tripdata.Sno AS tripid, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT UnitPrice,Categoryname, ProductName, Sno, Qty,catsno, productid FROM (SELECT        productsdata.UnitPrice,products_category.sno AS  catsno,products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty, productsdata.sno AS productid FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN  products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.tripid = ProductInfo.Sno ");
                                    cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                                    cmd.Parameters.Add("@d1", GetLowDate(dtfromdate));
                                    cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                                    DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                                    dtAll.Merge(dtsale_value);
                                }
                                DataView view = new DataView(dtAll);
                                DataTable distinctproducts = view.ToTable(true, "productid", "catsno", "Categoryname");
                                DataView dv = distinctproducts.DefaultView;
                                dv.Sort = "catsno";
                                DataTable sortedProductDT = dv.ToTable();
                                DateTime dtF = dtfromdate;
                                TimeSpan dateSpan2 = dttodate.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                double totalqty = 0; double totalsalevalue = 0;
                                foreach (DataRow drr in dtAll.Rows)
                                {
                                    double qty = 0;
                                    double.TryParse(drr["qty"].ToString(), out qty); ;
                                    totalqty += qty;
                                    double salevalue = 0;
                                    double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                    totalsalevalue += salevalue;
                                }
                                DataRow newrow = Report.NewRow();
                                newrow["Deliverqty"] = totalqty;
                                newrow["SaleValue"] = totalsalevalue;
                                double avgqty = 0;
                                avgqty = totalqty / NoOfdays;
                                newrow["AvgQty"] = avgqty.ToString("F2");
                                //newrow["Week"] = weekid;
                                newrow["Week"] = "" + weekid + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                Report.Rows.Add(newrow);
                                //foreach (DataRow drs in sortedProductDT.Rows)
                                //{
                                //    double totalqty = 0; double totalsalevalue = 0;
                                //    foreach (DataRow drr in dtAll.Select("productid='" + drs["productid"].ToString() + "'"))
                                //    {

                                //        double qty = 0;
                                //        double.TryParse(drr["qty"].ToString(), out qty); ;
                                //        totalqty += qty;
                                //        double salevalue = 0;
                                //        double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                                //        totalsalevalue += salevalue;
                                //    }
                                //    DataRow newrow = Report.NewRow();
                                //    newrow["Deliverqty"] = totalqty;
                                //    newrow["SaleValue"] = totalsalevalue;
                                //    double avgqty = 0;
                                //    avgqty = totalqty / NoOfdays;
                                //    newrow["AvgQty"] = avgqty.ToString("F2");
                                //    //newrow["Week"] = weekid;
                                //    newrow["Week"] = "" + weekid + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                //    Report.Rows.Add(newrow);
                                //}
                            }
                            else if (branchtype == "Plant")
                            {
                                cmd = new MySqlCommand("SELECT  TripInfo.Sno, TripInfo.DCNo, ProductInfo.ProductName, ProductInfo.Categoryname,ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno FROM  (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT  Categoryname, ProductName,UnitPrice, Sno, Qty, CatSno,productid FROM   (SELECT  productsdata.UnitPrice,productsdata.sno AS productid,products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM   tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE   (tripdata_1.AssignDate BETWEEN @d1 AND @d2)) TripSubInfo) ProductInfo ON TripInfo.Sno = ProductInfo.Sno ");
                                cmd.Parameters.Add("@branch", branchid);
                                cmd.Parameters.Add("@SOID", branchid);
                                cmd.Parameters.Add("@d1", GetLowDate(dtfromdate));
                                cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                                dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                            }
                            else
                            {
                                cmd = new MySqlCommand("SELECT  ROUND(indents_subtable.UnitCost, 2) AS cost, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, products_category.Categoryname, productsdata.ProductName,  productsdata.sno AS productid, products_category.sno AS catsno  FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN branchmappingtable ON indents.Branch_id = branchmappingtable.SubBranch WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchmappingtable.SuperBranch = @brnchid) ");
                                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                                cmd.Parameters.Add("@brnchid", branchid);
                                cmd.Parameters.Add("@d1", GetLowDate(dtfromdate));
                                cmd.Parameters.Add("@d2", GetHighDate(dttodate));
                                dtsalevalue = vdm.SelectQuery(cmd).Tables[0];
                            }
                            foreach (DataRow drsv in dtsalevalue.Rows)
                            {

                                DataRow newrow = Report.NewRow();
                                newrow["Deliverqty"] = drsv["DeliveryQty"].ToString();
                                newrow["SaleValue"] = drsv["salevalue"].ToString();
                                TimeSpan dateSpan = dttodate.Subtract(dtfromdate);
                                double days = dateSpan.TotalDays;
                                double delQty = 0;
                                double.TryParse(drsv["DeliveryQty"].ToString(), out delQty);
                                double qty = 0;
                                qty = delQty / days;
                                newrow["AvgQty"] = qty.ToString("f2");
                                //newrow["Week"] = weekid;
                                newrow["Week"] = "" + weekid + "__" + ChangedTime1 + "__" + ChangedTime2 + "";
                                Report.Rows.Add(newrow);
                            }
                        }
                    }
                }
                List<SalelDetails> SalelDetailslist1 = new List<SalelDetails>();
                foreach (DataRow drsale in Report.Rows)
                {
                    float qty = 0; float lqty = 0; float rqty = 0; float sqty = 0; float dqty = 0;
                    float netqty = 0;
                    SalelDetails getsalevaluedetails = new SalelDetails();
                    float.TryParse(drsale["Deliverqty"].ToString(), out dqty);
                    float.TryParse(drsale["AvgQty"].ToString(), out lqty);
                    float lsqty = lqty + sqty;
                    float drqty = rqty + dqty;
                    netqty = drqty - lsqty;
                    getsalevaluedetails.Deliverqty = dqty.ToString();
                    getsalevaluedetails.LeakQty = lqty.ToString();
                    getsalevaluedetails.ReturnQty = rqty.ToString();
                    getsalevaluedetails.idate = drsale["IndentDate"].ToString();
                    getsalevaluedetails.salevalue = drsale["SaleValue"].ToString();
                    getsalevaluedetails.NetQty = netqty.ToString();
                    getsalevaluedetails.ddltype = type;
                    getsalevaluedetails.productname = "W" + drsale["Week"].ToString();
                    SalelDetailslist1.Add(getsalevaluedetails);
                }
                string response = GetJson(SalelDetailslist1);
                context.Response.Write(response);
            }
            catch
            {
            }
        }


        private void get_BranchWiseProductsData(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Productid = context.Request["productid"];
                string[] arr = Productid.Split('_');
                string t1 = arr.Length.ToString();
                string branchid = "";
                if (t1 == "1")
                {
                    Productid = arr[0];
                    branchid = context.Request["branchname"];
                }
                else
                {
                    branchid = arr[0];
                    Productid = arr[1];
                }
                //string FromDate = context.Request["startDate"];
                //DateTime From_Date = Convert.ToDateTime(FromDate);
                //string Todate = context.Request["endDate"];
                //DateTime Enddate = Convert.ToDateTime(Todate);

                string s = context.Request["startDate"];
                var dt = DateTime.ParseExact(s, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string FromDate = dt.ToString("yyyy-MM-dd");
                DateTime From_Date = Convert.ToDateTime(FromDate);

                string e = context.Request["endDate"];
                var edt = DateTime.ParseExact(e, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string Todate = edt.ToString("yyyy-MM-dd");
                DateTime Enddate = Convert.ToDateTime(Todate);

                DateTime firstmonth = new DateTime();
                DateTime lastmonth = new DateTime();
                DataTable Report = new DataTable();
                Report.Columns.Add("Branchid");
                Report.Columns.Add("BranchName");
                Report.Columns.Add("ProductName");
                Report.Columns.Add("ProductId");
                Report.Columns.Add("SaleValue");
                Report.Columns.Add("DelivaryQty");

                DataTable dtsalevalue = new DataTable();
                DataTable dtlekages = new DataTable();
                cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                cmd.Parameters.Add("@Branchid", branchid);
                DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                string branchtype = "";
                if (dttable.Rows.Count > 0)
                {
                    branchtype = dttable.Rows[0]["salestype"].ToString();
                }
                if (branchid == "1")
                {
                    cmd = new MySqlCommand("SELECT  sno, BranchName, SalesType, flag, companycode FROM branchdata WHERE  (companycode = @companycode) AND (SalesType = @SalesType) AND (flag <> 0)");
                    cmd.Parameters.Add("@companycode", branchid);
                    cmd.Parameters.Add("@SalesType", "23");
                    DataTable dtplats = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtAll = new DataTable();
                    foreach (DataRow drplants in dtplats.Rows)
                    {
                        cmd = new MySqlCommand("SELECT  TripInfo.Sno, ProductInfo.ProductName, ProductInfo.Categoryname, ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty,SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno, TripInfo.BranchID, TripInfo.BranchName FROM  (SELECT  tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode, branchdata.BranchName, dispatch.BranchID FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE  (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT  Categoryname, ProductName, Sno, Qty, CatSno, productid,UnitPrice FROM  (SELECT  productsdata.UnitPrice,productsdata.sno AS productid, products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2) AND (productsdata.sno = @productid)) TripSubInfo) ProductInfo ON  TripInfo.Sno = ProductInfo.Sno GROUP BY ProductInfo.productid");
                        cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                        cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                        cmd.Parameters.Add("@productid", Productid);
                        cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                        DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                        dtAll.Merge(dtsale_value);
                    }
                    DataView view = new DataView(dtAll);
                    DataTable distinctproducts = view.ToTable(true, "productid");
                    string ProductName = "";
                    string CategoeryName = "";
                    foreach (DataRow dr in distinctproducts.Rows)
                    {
                        double totalqty = 0; double tsalevalue = 0;
                        foreach (DataRow drr in dtAll.Select("productid='" + dr["productid"].ToString() + "'"))
                        {
                            double qty = 0;
                            double.TryParse(drr["DeliveryQty"].ToString(), out qty); ;
                            double salevalue = 0;
                            double.TryParse(drr["salevalue"].ToString(), out salevalue); ;
                            CategoeryName = drr["Categoryname"].ToString();
                            ProductName = drr["ProductName"].ToString();
                            //totalqty += qty;
                            //tsalevalue += salevalue;
                            DataRow newrow = Report.NewRow();
                            newrow["DelivaryQty"] = qty;
                            newrow["SaleValue"] = Math.Round(salevalue, 2);
                            newrow["ProductName"] = ProductName;
                            newrow["ProductId"] = drr["productid"].ToString();
                            newrow["BranchName"] = drr["BranchName"].ToString();
                            foreach (DataRow drbranchid in dtplats.Select("BranchName='" + drr["BranchName"].ToString() + "'"))
                            {
                                newrow["Branchid"] = drbranchid["sno"].ToString();
                            }
                            Report.Rows.Add(newrow);
                        }
                    }
                }
                else if (branchtype == "Plant")
                {
                    //cmd = new MySqlCommand("SELECT   branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchmappingtable_1.SubBranch AS Expr1, branchdata.BranchName FROM branchmappingtable INNER JOIN branchmappingtable branchmappingtable_1 ON branchmappingtable.SubBranch = branchmappingtable_1.SubBranch INNER JOIN branchdata ON branchmappingtable_1.SubBranch = branchdata.sno WHERE (branchmappingtable.SuperBranch = @Branchid) AND (branchdata.flag <> 0) GROUP BY branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchmappingtable_1.SubBranch, branchdata.BranchName");
                    //cmd.Parameters.Add("@Branchid", context.Session["branch"]);
                    //DataTable dtbranches = vdm.SelectQuery(cmd).Tables[0];
                    cmd = new MySqlCommand("SELECT   TripInfo.Sno, ProductInfo.ProductName, ProductInfo.Categoryname, ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty, SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno, TripInfo.BranchID, TripInfo.BranchName FROM (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode, branchdata.BranchName, dispatch.BranchID FROM  branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT        Categoryname, ProductName, Sno, Qty, CatSno, productid, UnitPrice FROM            (SELECT        productsdata.UnitPrice, productsdata.sno AS productid, products_category.sno AS CatSno, products_category.Categoryname,  productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN  products_category ON products_subcategory.category_sno = products_category.sno WHERE  (tripdata_1.AssignDate BETWEEN @d1 AND @d2) AND (productsdata.sno = @productid)) TripSubInfo) ProductInfo ON  TripInfo.Sno = ProductInfo.Sno GROUP BY TripInfo.BranchID");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@productid", Productid);
                    cmd.Parameters.Add("@branch", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in routes.Rows)
                    {
                        cmd = new MySqlCommand("SELECT   sno,BranchName FROM branchdata WHERE  (sno = @BranchID)");
                        cmd.Parameters.Add("@BranchID", dr["BranchID"].ToString());
                        DataTable dtbranchname = vdm.SelectQuery(cmd).Tables[0];
                        string BranchName = dtbranchname.Rows[0]["BranchName"].ToString();
                        string Branchid = dtbranchname.Rows[0]["sno"].ToString();
                        DataRow newrow = Report.NewRow();
                        double deliverqty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out deliverqty);
                        double salevalue = 0;
                        double.TryParse(dr["salevalue"].ToString(), out salevalue);
                        newrow["BranchName"] = BranchName;
                        newrow["DelivaryQty"] = Math.Round(deliverqty, 2);
                        newrow["SaleValue"] = Math.Round(salevalue, 2);
                        newrow["Branchid"] = dr["Branchid"].ToString();
                        newrow["ProductId"] = dr["productid"].ToString();
                        Report.Rows.Add(newrow);
                    }
                }
                else if (branchtype == "SALES OFFICE")
                {
                    cmd = new MySqlCommand("SELECT  modifiedroutes.Sno, modifiedroutes.RouteName, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty,ROUND(SUM(DeliveryQty * UnitCost), 2) AS salevalue FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN tripdata ON indents_subtable.DTripId = tripdata.Sno WHERE (modifiedroutes.BranchID = @BranchID) AND (modifiedroutesubtable.EDate IS NULL)  AND (modifiedroutesubtable.CDate <= @d1) AND (indents_subtable.Product_sno = @productsno) OR (modifiedroutes.BranchID = @BranchID) AND (modifiedroutesubtable.EDate > @d1)  AND (modifiedroutesubtable.CDate <= @d1) AND (indents_subtable.Product_sno = @ProductSno) GROUP BY modifiedroutes.Sno, productsdata.sno");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@productsno", Productid);
                    cmd.Parameters.Add("@BranchID", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in routes.Rows)
                    {
                        DataRow newrow = Report.NewRow();
                        double deliverqty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out deliverqty);
                        double salevalue = 0;
                        double.TryParse(dr["salevalue"].ToString(), out salevalue);
                        newrow["BranchName"] = dr["RouteName"].ToString();
                        newrow["DelivaryQty"] = Math.Round(deliverqty, 2);
                        newrow["SaleValue"] = Math.Round(salevalue, 2);
                        newrow["Branchid"] = dr["Sno"].ToString();
                        newrow["ProductId"] = dr["Product_sno"].ToString();
                        Report.Rows.Add(newrow);
                    }
                }
                else
                {
                    cmd = new MySqlCommand("SELECT   modifiedroutes.Sno, modifiedroutes.RouteName, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, branchdata.BranchName FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT  IndentNo, Branch_id, I_date FROM  indents WHERE (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN tripdata ON indents_subtable.DTripId = tripdata.Sno WHERE (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) AND (indents_subtable.Product_sno = @productsno) AND  (modifiedroutes.Sno = @BranchID) OR (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (indents_subtable.Product_sno = @ProductSno) AND  (modifiedroutes.Sno = @BranchID) GROUP BY modifiedroutesubtable.BranchID, productsdata.sno");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@productsno", Productid);
                    cmd.Parameters.Add("@BranchID", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in routes.Rows)
                    {
                        DataRow newrow = Report.NewRow();
                        double deliverqty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out deliverqty);
                        double salevalue = 0;
                        double.TryParse(dr["salevalue"].ToString(), out salevalue);
                        newrow["BranchName"] = dr["BranchName"].ToString();
                        newrow["DelivaryQty"] = Math.Round(deliverqty, 2);
                        newrow["SaleValue"] = Math.Round(salevalue, 2);
                        newrow["Branchid"] = dr["Sno"].ToString();
                        newrow["ProductId"] = dr["Product_sno"].ToString();
                        Report.Rows.Add(newrow);
                    }
                }
                List<SalelDetails> branchwiseproductlist = new List<SalelDetails>();
                foreach (DataRow drr in Report.Rows)
                {
                    SalelDetails obj2 = new SalelDetails();
                    obj2.Branchid = drr["Branchid"].ToString();
                    obj2.BranchName = drr["BranchName"].ToString();
                    obj2.Deliverqty = drr["DelivaryQty"].ToString();
                    obj2.salevalue = drr["SaleValue"].ToString();
                    obj2.productid = drr["ProductId"].ToString();
                    obj2.produtandBranchid = "" + drr["Branchid"].ToString() + "_" + drr["ProductId"].ToString() + "";
                    branchwiseproductlist.Add(obj2);
                }
                string response = GetJson(branchwiseproductlist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string Response = GetJson(ex.Message);
                context.Response.Write(Response);
            }
        }



        private void GetCategoryWiseChart(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string categoryid = context.Request["categoryid"];
                string[] arr = categoryid.Split('_');
                string t1 = arr.Length.ToString();
                string branchid = "";
                if (t1 == "1")
                {
                    categoryid = arr[0];
                    branchid = context.Request["branchname"];
                }
                else
                {
                    branchid = arr[0];
                    categoryid = arr[1];
                }
                string s = context.Request["startDate"];
                var dt = DateTime.ParseExact(s, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string FromDate = dt.ToString("yyyy-MM-dd");
                DateTime From_Date = Convert.ToDateTime(FromDate);

                string e = context.Request["endDate"];
                var edt = DateTime.ParseExact(e, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);
                string Todate = edt.ToString("yyyy-MM-dd");
                DateTime Enddate = Convert.ToDateTime(Todate);

                TimeSpan dateSpan = Enddate.Subtract(From_Date);
                //int days=dateSpan + 1;
                int days = dateSpan.Days;
                int NoOfdays = days + 1;

                List<PieValues> lPieValueslist = new List<PieValues>();
                List<string> RouteList = new List<string>();
                List<string> AmountList = new List<string>();
                List<string> DeliveryList = new List<string>();
                List<string> AvgQtyList = new List<string>();

                List<string> categoryidlist = new List<string>();
                List<PieValueTableClass> PieValueTableClasslist = new List<PieValueTableClass>();
                DataTable dtsalevalue = new DataTable();
                DataTable dtlekages = new DataTable();
                cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                cmd.Parameters.Add("@Branchid", branchid);
                DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                string branchtype = "";
                if (dttable.Rows.Count > 0)
                {
                    branchtype = dttable.Rows[0]["salestype"].ToString();
                }
                if (branchid == "1")
                {
                    cmd = new MySqlCommand("SELECT  sno, BranchName, SalesType, flag, companycode FROM branchdata WHERE  (companycode = @companycode) AND (SalesType = @SalesType) AND (flag <> 0)");
                    cmd.Parameters.Add("@companycode", branchid);
                    cmd.Parameters.Add("@SalesType", "23");
                    DataTable dtplats = vdm.SelectQuery(cmd).Tables[0];
                    DataTable dtAll = new DataTable();
                    foreach (DataRow drplants in dtplats.Rows)
                    {
                        cmd = new MySqlCommand("SELECT TripInfo.Sno, ProductInfo.ProductName, ProductInfo.Categoryname, ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty, SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType,TripInfo.DispMode, ProductInfo.CatSno, TripInfo.BranchID, TripInfo.BranchName FROM (SELECT  tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode, branchdata.BranchName, dispatch.BranchID FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT  Categoryname, ProductName, Sno, Qty, CatSno, productid, UnitPrice FROM  (SELECT productsdata.UnitPrice, productsdata.sno AS productid, products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2) AND (products_category.sno = @categoryid)) TripSubInfo) ProductInfo ON  TripInfo.Sno = ProductInfo.Sno GROUP BY ProductInfo.CatSno");
                        cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                        cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                        cmd.Parameters.Add("@categoryid", categoryid);
                        cmd.Parameters.Add("@branch", drplants["sno"].ToString());
                        DataTable dtsale_value = vdm.SelectQuery(cmd).Tables[0];
                        dtAll.Merge(dtsale_value);
                    }

                    DataView view = new DataView(dtAll);
                    DataTable distinctproducts = view.ToTable(true, "CatSno", "BranchName");
                    string ProductName = "";
                    string CategoeryName = "";
                    double totalqty = 0;
                    foreach (DataRow dr in distinctproducts.Rows)
                    {

                        foreach (DataRow drr in dtAll.Select("CatSno='" + dr["CatSno"].ToString() + "'AND BranchName='" + dr["BranchName"].ToString() + "'"))
                        {
                            double DeliveryQty = 0;
                            double.TryParse(drr["DeliveryQty"].ToString(), out DeliveryQty);
                            totalqty += DeliveryQty;
                            totalqty = Math.Round(totalqty, 2);
                        }
                    }
                    foreach (DataRow dr in distinctproducts.Rows)
                    {

                        foreach (DataRow drr in dtAll.Select("CatSno='" + dr["CatSno"].ToString() + "'AND BranchName='" + dr["BranchName"].ToString() + "'"))
                        {
                            string BranchName = ""; string BranchID = "";
                            foreach (DataRow drbranchid in dtplats.Select("BranchName='" + dr["BranchName"].ToString() + "'"))
                            {
                                BranchName = drbranchid["BranchName"].ToString();
                                BranchID = drbranchid["sno"].ToString();
                                RouteList.Add(BranchName);
                            }
                            double DeliveryQty = 0;
                            double.TryParse(drr["DeliveryQty"].ToString(), out DeliveryQty);
                            double avgqty = 0;
                            avgqty = DeliveryQty / NoOfdays;
                            double percent = 0;
                            percent = (DeliveryQty / totalqty) * 100;
                            percent = Math.Round(percent, 2);
                            avgqty = Math.Round(avgqty, 2);
                            string Amount = percent.ToString();
                            if (Amount == "")
                            {
                                Amount = "0";
                            }
                            AmountList.Add(DeliveryQty.ToString());
                            AvgQtyList.Add(avgqty.ToString());
                            DeliveryList.Add(drr["DeliveryQty"].ToString());
                            categoryidlist.Add("" + BranchID + "_" + drr["CatSno"].ToString() + "");
                            PieValueTableClass obj1 = new PieValueTableClass();
                            obj1.RouteName = BranchName;
                            obj1.DeliveryQty = DeliveryQty.ToString();
                            obj1.AverageyQty = avgqty.ToString();
                            obj1.Routeid = "" + BranchID + "_" + drr["CatSno"].ToString() + "";
                            //obj1.RouteName = BranchName;
                            PieValueTableClasslist.Add(obj1);
                        }
                    }
                    PieValues GetPieValues = new PieValues();
                    GetPieValues.RouteName = RouteList;
                    GetPieValues.Amount = AmountList;
                    GetPieValues.catidandBranchid = categoryidlist;
                    GetPieValues.totalqty = totalqty.ToString();
                    GetPieValues.DeliveryQty = DeliveryList;
                    GetPieValues.AverageyQty = AvgQtyList;
                    GetPieValues.PieValueTableClass = PieValueTableClasslist;
                    lPieValueslist.Add(GetPieValues);
                    //}
                    string errresponse = GetJson(lPieValueslist);
                    context.Response.Write(errresponse);
                }
                else if (branchtype == "Plant")
                {

                    cmd = new MySqlCommand("SELECT  TripInfo.Sno, ProductInfo.ProductName, ProductInfo.Categoryname, ProductInfo.productid, SUM(ProductInfo.Qty) AS DeliveryQty, SUM(ProductInfo.UnitPrice * ProductInfo.Qty) AS salevalue, TripInfo.I_Date, TripInfo.VehicleNo, TripInfo.Status, TripInfo.DispName, TripInfo.DispType, TripInfo.DispMode, ProductInfo.CatSno, TripInfo.BranchID, TripInfo.BranchName FROM  (SELECT tripdata.Sno, tripdata.DCNo, tripdata.I_Date, tripdata.VehicleNo, tripdata.Status, dispatch.DispName, dispatch.DispType, dispatch.DispMode, branchdata.BranchName, dispatch.BranchID FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (dispatch.Branch_Id = @branch) AND (tripdata.AssignDate BETWEEN @d1 AND @d2)) TripInfo INNER JOIN (SELECT Categoryname, ProductName, Sno, Qty, CatSno, productid, UnitPrice FROM  (SELECT productsdata.UnitPrice, productsdata.sno AS productid, products_category.sno AS CatSno, products_category.Categoryname, productsdata.ProductName, tripdata_1.Sno, tripsubdata.Qty FROM  tripdata tripdata_1 INNER JOIN tripsubdata ON tripdata_1.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (tripdata_1.AssignDate BETWEEN @d1 AND @d2) AND (products_category.sno = @categoryid)) TripSubInfo) ProductInfo ON  TripInfo.Sno = ProductInfo.Sno GROUP BY TripInfo.BranchID");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@categoryid", categoryid);
                    cmd.Parameters.Add("@branch", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    double totalqty = 0;
                    foreach (DataRow dr in routes.Rows)
                    {
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        totalqty += DeliveryQty;
                        totalqty = Math.Round(totalqty, 2);
                    }
                    foreach (DataRow dr in routes.Rows)
                    {

                        cmd = new MySqlCommand("SELECT   sno,BranchName FROM branchdata WHERE  (sno = @BranchID)");
                        cmd.Parameters.Add("@BranchID", dr["BranchID"].ToString());
                        DataTable dtbranchname = vdm.SelectQuery(cmd).Tables[0];
                        string BranchName = dtbranchname.Rows[0]["BranchName"].ToString();
                        string Branchid = dtbranchname.Rows[0]["sno"].ToString();
                        RouteList.Add(BranchName);
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        double avgqty = 0;
                        avgqty = DeliveryQty / NoOfdays;
                        double percent = 0;
                        percent = (DeliveryQty / totalqty) * 100;
                        percent = Math.Round(percent, 2);
                        avgqty = Math.Round(avgqty, 2);
                        string Amount = percent.ToString();
                        if (Amount == "")
                        {
                            Amount = "0";
                        }
                        AmountList.Add(DeliveryQty.ToString());
                        AvgQtyList.Add(avgqty.ToString());
                        DeliveryList.Add(dr["DeliveryQty"].ToString());
                        categoryidlist.Add("" + dr["BranchID"].ToString() + "_" + dr["CatSno"].ToString() + "");
                        PieValueTableClass obj1 = new PieValueTableClass();
                        obj1.RouteName = BranchName;
                        obj1.DeliveryQty = DeliveryQty.ToString();
                        obj1.AverageyQty = avgqty.ToString();
                        obj1.Routeid = "" + dr["BranchID"].ToString() + "_" + dr["CatSno"].ToString() + "";
                        PieValueTableClasslist.Add(obj1);
                    }
                    PieValues GetPieValues = new PieValues();
                    GetPieValues.RouteName = RouteList;
                    GetPieValues.Amount = AmountList;
                    GetPieValues.catidandBranchid = categoryidlist;
                    GetPieValues.totalqty = totalqty.ToString();
                    GetPieValues.DeliveryQty = DeliveryList;
                    GetPieValues.AverageyQty = AvgQtyList;
                    GetPieValues.PieValueTableClass = PieValueTableClasslist;
                    lPieValueslist.Add(GetPieValues);
                    //}
                    string errresponse = GetJson(lPieValueslist);
                    context.Response.Write(errresponse);
                }
                else if (branchtype == "SALES OFFICE")
                {
                    cmd = new MySqlCommand("SELECT  modifiedroutes.Sno, modifiedroutes.RouteName, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, products_category.sno AS CatSno FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM  indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON products_subcategory.sno = productsdata.SubCat_sno INNER JOIN products_category ON products_category.sno = products_subcategory.category_sno INNER JOIN tripdata ON indents_subtable.DTripId = tripdata.Sno WHERE  (modifiedroutes.BranchID = @BranchID) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) AND  (products_category.sno = @categoryid) OR (modifiedroutes.BranchID = @BranchID) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND  (products_category.sno = @categoryid) GROUP BY modifiedroutes.Sno, products_category.sno");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@categoryid", categoryid);
                    cmd.Parameters.Add("@BranchID", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    double totalqty = 0;
                    foreach (DataRow dr in routes.Rows)
                    {
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        totalqty += DeliveryQty;
                        totalqty = Math.Round(totalqty, 2);
                    }
                    foreach (DataRow dr in routes.Rows)
                    {

                        RouteList.Add(dr["RouteName"].ToString());
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        double avgqty = 0;
                        avgqty = DeliveryQty / NoOfdays;
                        double percent = 0;
                        percent = (DeliveryQty / totalqty) * 100;
                        percent = Math.Round(percent, 2);
                        avgqty = Math.Round(avgqty, 2);
                        string Amount = percent.ToString();
                        if (Amount == "")
                        {
                            Amount = "0";
                        }
                        AmountList.Add(DeliveryQty.ToString());
                        AvgQtyList.Add(avgqty.ToString());
                        DeliveryList.Add(dr["DeliveryQty"].ToString());
                        categoryidlist.Add("" + dr["Sno"].ToString() + "_" + dr["CatSno"].ToString() + "");
                        PieValueTableClass obj1 = new PieValueTableClass();
                        obj1.RouteName = dr["RouteName"].ToString();
                        obj1.DeliveryQty = DeliveryQty.ToString();
                        obj1.AverageyQty = avgqty.ToString();
                        obj1.Routeid = "" + dr["Sno"].ToString() + "_" + dr["CatSno"].ToString() + "";
                        PieValueTableClasslist.Add(obj1);

                    }
                    PieValues GetPieValues = new PieValues();
                    GetPieValues.RouteName = RouteList;
                    GetPieValues.Amount = AmountList;
                    GetPieValues.catidandBranchid = categoryidlist;
                    GetPieValues.totalqty = totalqty.ToString();
                    GetPieValues.DeliveryQty = DeliveryList;
                    GetPieValues.AverageyQty = AvgQtyList;
                    GetPieValues.PieValueTableClass = PieValueTableClasslist;
                    lPieValueslist.Add(GetPieValues);
                    //}
                    string errresponse = GetJson(lPieValueslist);
                    context.Response.Write(errresponse);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT  modifiedroutes.Sno, modifiedroutes.RouteName,products_category.sno AS CatSno, indents_subtable.Product_sno, productsdata.ProductName, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, ROUND(SUM(indents_subtable.DeliveryQty * indents_subtable.UnitCost), 2) AS salevalue, branchdata.BranchName FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM  indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON products_subcategory.sno = productsdata.SubCat_sno INNER JOIN products_category ON products_category.sno = products_subcategory.category_sno INNER JOIN tripdata ON indents_subtable.DTripId = tripdata.Sno WHERE (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) AND (modifiedroutes.Sno = @BranchID) AND  (products_category.sno = @categoryid) OR (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (modifiedroutes.Sno = @BranchID) AND  (products_category.sno = @categoryid) GROUP BY modifiedroutesubtable.BranchID, products_category.sno");
                    cmd.Parameters.Add("@d1", GetLowDate(From_Date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(Enddate).AddDays(-1));
                    cmd.Parameters.Add("@categoryid", categoryid);
                    cmd.Parameters.Add("@BranchID", branchid);
                    DataTable routes = vdm.SelectQuery(cmd).Tables[0];
                    double totalqty = 0;
                    foreach (DataRow dr in routes.Rows)
                    {
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        totalqty += DeliveryQty;
                        totalqty = Math.Round(totalqty, 2);
                    }
                    foreach (DataRow dr in routes.Rows)
                    {

                        RouteList.Add(dr["BranchName"].ToString());
                        double DeliveryQty = 0;
                        double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                        double avgqty = 0;
                        avgqty = DeliveryQty / NoOfdays;
                        double percent = 0;
                        percent = (DeliveryQty / totalqty) * 100;
                        percent = Math.Round(percent, 2);
                        avgqty = Math.Round(avgqty, 2);
                        string Amount = percent.ToString();
                        if (Amount == "")
                        {
                            Amount = "0";
                        }
                        AmountList.Add(DeliveryQty.ToString());
                        AvgQtyList.Add(avgqty.ToString());
                        DeliveryList.Add(dr["DeliveryQty"].ToString());
                        categoryidlist.Add("" + dr["Sno"].ToString() + "_" + dr["CatSno"].ToString() + "");
                        PieValueTableClass obj1 = new PieValueTableClass();
                        obj1.RouteName = dr["BranchName"].ToString();
                        obj1.DeliveryQty = DeliveryQty.ToString();
                        obj1.AverageyQty = avgqty.ToString();
                        obj1.Routeid = "" + dr["Sno"].ToString() + "_" + dr["CatSno"].ToString() + "";
                        PieValueTableClasslist.Add(obj1);

                    }
                    PieValues GetPieValues = new PieValues();
                    GetPieValues.RouteName = RouteList;
                    GetPieValues.Amount = AmountList;
                    GetPieValues.catidandBranchid = categoryidlist;
                    GetPieValues.totalqty = totalqty.ToString();
                    GetPieValues.DeliveryQty = DeliveryList;
                    GetPieValues.AverageyQty = AvgQtyList;
                    GetPieValues.PieValueTableClass = PieValueTableClasslist;
                    lPieValueslist.Add(GetPieValues);
                    //}
                    string errresponse = GetJson(lPieValueslist);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        class InventaryDetails
        {
            public string BranchName { set; get; }
            public string opinventary { set; get; }
            public string issuinv { set; get; }
            public string recivinv { set; get; }
            public string balinv { set; get; }
        }
        private void GetInventoryDetails(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                //DataTable Report = new DataTable();
                //Report.Columns.Add("ProductName");
                //Report.Columns.Add("Deliverqty");
                //Report.Columns.Add("LeakQty");
                //Report.Columns.Add("ReturnQty");
                //Report.Columns.Add("ShortQty");
                //Report.Columns.Add("IndentDate");
                string Routebranchid = context.Request["Routebranchid"];
                string Date = context.Request["Date"];
                DateTime date = Convert.ToDateTime(Date);
                cmd = new MySqlCommand("SELECT inventory_monitor.Inv_Sno, inventory_monitor.BranchId, inventory_monitor.Qty, inventory_monitor.Sno, inventory_monitor.EmpId, inventory_monitor.lostQty FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN modifiedroutesubtable ON dispatch_sub.Route_id = modifiedroutesubtable.RefNo INNER JOIN inventory_monitor ON modifiedroutesubtable.BranchID = inventory_monitor.BranchId WHERE (dispatch.sno = @Routebranchid) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) OR (dispatch.sno = @Routebranchid) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1)");
                cmd.Parameters.Add("@Routebranchid", Routebranchid);
                cmd.Parameters.Add("@d1", GetLowDate(date));
                //cmd.Parameters.Add("@d2", GetHighDate(date));
                DataTable dtopinventaery = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno, modifiedroutes.RouteName, modifiedroutes.Sno AS routesno FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN modifiedroutes ON dispatch_sub.Route_id = modifiedroutes.Sno INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno WHERE (dispatch.sno = @Routebranchid) AND (branchdata.flag = '1') AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) OR (dispatch.sno = @Routebranchid) AND (branchdata.flag = '1') AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1)");
                cmd.Parameters.Add("@Routebranchid", Routebranchid);
                cmd.Parameters.Add("@d1", GetLowDate(date));
                DataTable dtragent = vdm.SelectQuery(cmd).Tables[0];
                DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                List<InventaryDetails> InventaryDetailslis = new List<InventaryDetails>();
                if (dtragent.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtragent.Rows)
                    {
                        //DataRow newrow = Report.NewRow();
                        InventaryDetails obj1 = new InventaryDetails();
                        double opqty = 0; double isueqty = 0; double recivqty = 0;
                        foreach (DataRow dropp in dtopinventaery.Select("BranchId='" + dr["sno"].ToString() + "'"))
                        {
                            int opcrtes = 0;
                            int.TryParse(dropp["Qty"].ToString(), out opcrtes);
                            opqty += opcrtes;
                        }
                        cmd = new MySqlCommand("SELECT invtras.TransType, invtras.FromTran, invtras.ToTran, invtras.Qty, invtras.DOE, invmaster.sno AS invsno, invmaster.InvName FROM (SELECT TransType, FromTran, ToTran, Qty, EmpID, VarifyStatus, VTripId, VEmpId, Sno, B_inv_sno, DOE, VQty FROM invtransactions12 WHERE  (DOE BETWEEN @d1 AND @d2) AND (FromTran = @branchid)) invtras INNER JOIN invmaster ON invtras.B_inv_sno = invmaster.sno ORDER BY invtras.DOE");
                        cmd.Parameters.Add("@branchid", dr["sno"].ToString());
                        DateTime dt1 = GetLowDate(date.AddDays(-1));
                        DateTime dt2 = GetLowDate(date);
                        cmd.Parameters.Add("@d1", dt1);
                        cmd.Parameters.Add("@d2", dt2);
                        DataTable dtissueinv = vdm.SelectQuery(cmd).Tables[0];
                        foreach (DataRow driss in dtissueinv.Rows)
                        {
                            int isscrates = 0;
                            int.TryParse(driss["Qty"].ToString(), out isscrates);
                            isueqty += isscrates;
                        }
                        cmd = new MySqlCommand("SELECT invtran.TransType, invtran.FromTran, invtran.ToTran, invtran.Qty, invtran.DOE, invmaster.sno AS invsno, invmaster.InvName FROM (SELECT TransType, FromTran, ToTran, Qty, EmpID, VarifyStatus, VTripId, VEmpId, Sno, B_inv_sno, DOE, VQty FROM invtransactions12 WHERE  (DOE BETWEEN @d1 AND @d2) AND (ToTran = @branchid)) invtran INNER JOIN invmaster ON invtran.B_inv_sno = invmaster.sno ORDER BY invtran.DOE");
                        cmd.Parameters.Add("@branchid", dr["sno"].ToString());
                        DateTime dtd1 = GetLowDate(date.AddDays(-1));
                        DateTime dtd2 = GetLowDate(date);
                        cmd.Parameters.Add("@d1", dtd1);
                        cmd.Parameters.Add("@d2", dtd2);
                        DataTable dtreciveinv = vdm.SelectQuery(cmd).Tables[0];
                        foreach (DataRow drrec in dtreciveinv.Rows)
                        {
                            int retuncrates = 0;
                            int.TryParse(drrec["Qty"].ToString(), out retuncrates);
                            recivqty += retuncrates;
                        }
                        double balanceqty = opqty + isueqty - recivqty;
                        obj1.opinventary = opqty.ToString();
                        obj1.issuinv = isueqty.ToString();
                        obj1.recivinv = recivqty.ToString();
                        obj1.balinv = balanceqty.ToString();
                        obj1.BranchName = dr["BranchName"].ToString();
                        InventaryDetailslis.Add(obj1);
                    }
                }
                string response = GetJson(InventaryDetailslis);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetRouteNameclick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string RouteID = "";
                DataTable dtRoutedata = new DataTable();
                string IndentType = context.Request["IndentType"];
                RouteID = context.Request["RouteID"];
                IndentType = "Indent1";
                cmd = new MySqlCommand("SELECT   dispatch.DispName, dispatch.sno, dispatch.Route_id FROM dispatch INNER JOIN branchdata ON dispatch.Branch_Id = branchdata.sno INNER JOIN branchdata branchdata_1 ON dispatch.Branch_Id = branchdata_1.sno WHERE (branchdata.sno = @BranchID) AND (dispatch.flag = @flag) OR (dispatch.flag = @flag) AND (branchdata_1.SalesOfficeID = @SOID)");
                cmd.Parameters.Add("@BranchID", RouteID);
                cmd.Parameters.Add("@SOID", RouteID);
                cmd.Parameters.Add("@flag", "1");
                dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                List<IndentClass> Indentlist = new List<IndentClass>();
                if (dtRoutedata.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtRoutedata.Rows)
                    {
                        IndentClass GetIndentrout = new IndentClass();
                        GetIndentrout.RouteName = dr["DispName"].ToString();
                        GetIndentrout.Route_id = dr["Route_id"].ToString();
                        GetIndentrout.sno = dr["sno"].ToString();
                        Indentlist.Add(GetIndentrout);
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void getAgent_Name(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtRoutedata = new DataTable();
                string IndentType = context.Request["IndentType"];
                string RouteID = context.Request["Routeid"];
                IndentType = "Indent1";
                cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM dispatch INNER JOIN dispatch_sub ON dispatch.sno = dispatch_sub.dispatch_sno INNER JOIN branchroutes ON dispatch_sub.Route_id = branchroutes.Sno INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (dispatch.Route_id = @dispsno)");
                cmd.Parameters.Add("@dispsno", RouteID);
                dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                List<IndentClass> Indentlist = new List<IndentClass>();
                if (dtRoutedata.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtRoutedata.Rows)
                    {
                        IndentClass GetIndentrout = new IndentClass();
                        GetIndentrout.AgentName = dr["BranchName"].ToString();
                        GetIndentrout.sno = dr["sno"].ToString();
                        Indentlist.Add(GetIndentrout);
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class IndentClass
        {
            public string RouteName { get; set; }
            public string unitQty { get; set; }
            public string ProductName { get; set; }
            public string Qty { get; set; }
            public string totalqty { get; set; }
            public string Categoryname { get; set; }
            public string SubCatName { get; set; }
            public string BranchName { get; set; }
            public string gtotqty { get; set; }
            public string AgentName { get; set; }
            public string sno { get; set; }
            public string Route_id { get; set; }

        }
        private void GetIndentReport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtIndentData = new DataTable();
                string RouteID = "";
                string IndentType = context.Request["IndentType"];
                string Date = context.Request["Date"];
                RouteID = context.Request["RouteID"];
                string BranchId = context.Request["Branchid"];
                IndentType = "Indent1";
                DateTime date = Convert.ToDateTime(Date);
                //if (RouteID != "")
                //{
                //    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                //    cmd.Parameters.Add("@dispsno", RouteID);
                //}
                if (RouteID != "ALL")
                {
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", RouteID);
                }
                else
                {
                    cmd = new MySqlCommand("select Route_id,IndentType from dispatch_sub where dispatch_sno=@dispsno");
                    cmd.Parameters.Add("@dispsno", BranchId);
                }
                DataTable dtrouteindenttype = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow drrouteitype in dtrouteindenttype.Rows)
                {
                    RouteID = drrouteitype["Route_id"].ToString();
                    IndentType = drrouteitype["IndentType"].ToString();
                }
                if (RouteID == "A")
                {
                    cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.unitQty), 2) AS QTY, indent.IndentType, productsdata.ProductName FROM (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @d1 AND @d2) AND (Branch_id = @Branchid)) indent INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno GROUP BY productsdata.ProductName");
                    //// cmd = new MySqlCommand("SELECT  SUM(indents_subtable.unitQty) AS QTY, indent.IndentType, modifiedroutesubtable.BranchID,productsdata.productname, products_subcategory.SubCatName, products_subcategory.sno FROM   modifiedroutes INNER JOIN  modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN  (SELECT  IndentNo, Branch_id, I_date, IndentType, Status FROM   indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN (SELECT  branch_sno, product_sno, Rank FROM  branchproducts WHERE   (branch_sno = @BranchID)) brnchprdt ON productsdata.sno = brnchprdt.product_sno WHERE   (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1)  AND (indent.Status <> 'D') AND (indent.IndentType = @itype) OR  (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) GROUP BY products_subcategory.SubCatName, products_subcategory.sno,productsdata.productname ORDER BY brnchprdt.Rank, modifiedroutesubtable.Rank");
                    DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                    cmd.Parameters.Add("@itype", IndentType);
                    //cmd.Parameters.Add("@TripID", RouteID);
                    cmd.Parameters.Add("@d1", GetLowDate(date));
                    cmd.Parameters.Add("@d2", GetHighDate(date));
                    cmd.Parameters.Add("@BranchID", BranchId);
                    dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {

                    if (RouteID != "ALL")
                    {
                        if (context.Session["IndentData"] == null)
                        {
                            ////cmd = new MySqlCommand("SELECT  SUM(indents_subtable.unitQty) AS QTY, indent.IndentType, modifiedroutesubtable.BranchID, products_subcategory.SubCatName, products_subcategory.sno FROM   modifiedroutes INNER JOIN  modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN  (SELECT  IndentNo, Branch_id, I_date, IndentType, Status FROM   indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN (SELECT  branch_sno, product_sno, Rank FROM  branchproducts WHERE   (branch_sno = @BranchID)) brnchprdt ON productsdata.sno = brnchprdt.product_sno WHERE  (modifiedroutes.Sno = @TripID) AND (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1)  AND (indent.Status <> 'D') AND (indent.IndentType = @itype) OR (modifiedroutes.Sno = @TripID) AND (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) GROUP BY products_subcategory.SubCatName, products_subcategory.sno ORDER BY brnchprdt.Rank, modifiedroutesubtable.Rank");
                            cmd = new MySqlCommand("SELECT SUM(indents_subtable.unitQty) AS QTY, indent.IndentType, modifiedroutesubtable.BranchID, productsdata.ProductName FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE  (modifiedroutes.Sno = @TripID) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) OR (modifiedroutes.Sno = @TripID) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (indent.Status <> 'D') AND  (indent.IndentType = @itype)  GROUP BY productsdata.ProductName ORDER BY modifiedroutesubtable.Rank");
                            DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                            cmd.Parameters.Add("@itype", IndentType);
                            cmd.Parameters.Add("@TripID", RouteID);
                            cmd.Parameters.Add("@d1", GetLowDate(date));
                            cmd.Parameters.Add("@d2", GetHighDate(date));
                            cmd.Parameters.Add("@BranchID", BranchId);
                            dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            context.Session["IndentData"] = dtIndentData;
                        }
                    }
                    else if (RouteID == "ALL")
                    {
                        if (context.Session["IndentData"] == null)
                        {
                            cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.unitQty), 2) AS QTY, indent.IndentType, modifiedroutesubtable.BranchID, productsdata.ProductName FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN (SELECT IndentNo, Branch_id, I_date, IndentType, Status FROM  indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (modifiedroutes.BranchID = @BranchID) GROUP BY productsdata.ProductName, modifiedroutes.BranchID ORDER BY modifiedroutesubtable.Rank");
                            //// cmd = new MySqlCommand("SELECT  SUM(indents_subtable.unitQty) AS QTY, indent.IndentType, modifiedroutesubtable.BranchID,productsdata.productname, products_subcategory.SubCatName, products_subcategory.sno FROM   modifiedroutes INNER JOIN  modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN branchdata ON modifiedroutesubtable.BranchID = branchdata.sno INNER JOIN  (SELECT  IndentNo, Branch_id, I_date, IndentType, Status FROM   indents WHERE  (I_date BETWEEN @d1 AND @d2)) indent ON branchdata.sno = indent.Branch_id INNER JOIN indents_subtable ON indent.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno INNER JOIN (SELECT  branch_sno, product_sno, Rank FROM  branchproducts WHERE   (branch_sno = @BranchID)) brnchprdt ON productsdata.sno = brnchprdt.product_sno WHERE   (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate IS NULL) AND (modifiedroutesubtable.CDate <= @d1)  AND (indent.Status <> 'D') AND (indent.IndentType = @itype) OR  (brnchprdt.branch_sno = @BranchID) AND (modifiedroutesubtable.EDate > @d1) AND (modifiedroutesubtable.CDate <= @d1) AND (indent.Status <> 'D') AND (indent.IndentType = @itype) GROUP BY products_subcategory.SubCatName, products_subcategory.sno,productsdata.productname ORDER BY brnchprdt.Rank, modifiedroutesubtable.Rank");
                            DateTime Currentdate = VehicleDBMgr.GetTime(vdm.conn);
                            cmd.Parameters.Add("@itype", IndentType);
                            //cmd.Parameters.Add("@TripID", RouteID);
                            cmd.Parameters.Add("@d1", GetLowDate(date));
                            cmd.Parameters.Add("@d2", GetHighDate(date));
                            cmd.Parameters.Add("@BranchID", BranchId);
                            dtIndentData = vdm.SelectQuery(cmd).Tables[0];
                        }
                        else
                        {
                            context.Session["IndentData"] = dtIndentData;
                        }
                    }
                }
                List<IndentClass> Indentlist = new List<IndentClass>();
                string SubCatName = ""; string tempsubcatname = "";
                if (dtIndentData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtIndentData.Rows)
                    {
                        IndentClass getindent = new IndentClass();
                        getindent.SubCatName = dr["productname"].ToString();
                        //getindent.sno = dr["sno"].ToString();
                        string Totalqty = dr["QTY"].ToString();
                        double qty = 0;
                        double.TryParse(Totalqty, out qty);
                        qty = Math.Round(qty, 2);
                        getindent.totalqty = qty.ToString();
                        Indentlist.Add(getindent);
                    }
                }
                string response = GetJson(Indentlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class Route
        {
            public string rid { set; get; }
            public string RouteName { set; get; }
            public string Branchid { set; get; }
        }
        private void GetCsodispatchRoutes(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string branchid;
                DataTable dtRoutedata = new DataTable();
                string type = context.Session["salestype"].ToString();
                string formtype = context.Request["formtype"];
                if (type == "Plant")
                {

                    dtRoutedata.Columns.Add("BranchName");
                    dtRoutedata.Columns.Add("sno");
                    if (formtype == "sales" || formtype=="BalanceIncDec")
                    {
                        DataRow newrow3 = dtRoutedata.NewRow();
                        newrow3["BranchName"] = "SVDS";
                        newrow3["sno"] = "1";
                        dtRoutedata.Rows.Add(newrow3);

                        cmd = new MySqlCommand("SELECT BranchName, sno FROM  branchdata WHERE (sno = @BranchID)");
                        cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                        DataTable dtPlant = vdm.SelectQuery(cmd).Tables[0];
                        foreach (DataRow dr in dtPlant.Rows)
                        {
                            DataRow newrow1 = dtRoutedata.NewRow();
                            newrow1["BranchName"] = dr["BranchName"].ToString();
                            newrow1["sno"] = dr["sno"].ToString();
                            dtRoutedata.Rows.Add(newrow1);
                        }
                        cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @SuperBranch) and (branchdata.SalesType=@SalesType)  ");
                        cmd.Parameters.Add("@SuperBranch", context.Session["branch"]);
                        cmd.Parameters.Add("@SalesType", "23");
                        DataTable dtNewPlant = vdm.SelectQuery(cmd).Tables[0];
                        foreach (DataRow dr in dtNewPlant.Rows)
                        {
                            DataRow newrow2 = dtRoutedata.NewRow();
                            newrow2["BranchName"] = dr["BranchName"].ToString();
                            newrow2["sno"] = dr["sno"].ToString();
                            dtRoutedata.Rows.Add(newrow2);
                        }
                    }
                    //cmd = new MySqlCommand("SELECT BranchName, sno FROM  branchdata WHERE (sno = @BranchID)");
                    //cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                    //DataTable dtPlant1 = vdm.SelectQuery(cmd).Tables[0];
                    //foreach (DataRow dr in dtPlant1.Rows)
                    //{
                    //    DataRow newrow1 = dtRoutedata.NewRow();
                    //    newrow1["BranchName"] = dr["BranchName"].ToString();
                    //    newrow1["sno"] = dr["sno"].ToString();
                    //    dtRoutedata.Rows.Add(newrow1);
                    //}
                    //cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @SuperBranch) and (branchdata.SalesType=@SalesType)  ");
                    //cmd.Parameters.Add("@SuperBranch", context.Session["branch"]);
                    //cmd.Parameters.Add("@SalesType", "23");
                    //DataTable dtNewPlant1 = vdm.SelectQuery(cmd).Tables[0];
                    //foreach (DataRow dr in dtNewPlant1.Rows)
                    //{
                    //    DataRow newrow2 = dtRoutedata.NewRow();
                    //    newrow2["BranchName"] = dr["BranchName"].ToString();
                    //    newrow2["sno"] = dr["sno"].ToString();
                    //    dtRoutedata.Rows.Add(newrow2);
                    //}
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @SuperBranch) and (branchdata.SalesType=@SalesType) or (branchmappingtable.SuperBranch = @SuperBranch) and (branchdata.SalesType=@SalesType1)  ");
                    cmd.Parameters.Add("@SuperBranch", context.Session["branch"]);
                    cmd.Parameters.Add("@SalesType", "21");
                    cmd.Parameters.Add("@SalesType1", "26");
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        DataRow newrow = dtRoutedata.NewRow();
                        newrow["BranchName"] = dr["BranchName"].ToString();
                        newrow["sno"] = dr["sno"].ToString();
                        dtRoutedata.Rows.Add(newrow);
                    }
                }
                else if (context.Session["salestype"] == "Group")
                {
                    cmd = new MySqlCommand("SELECT dispatch.DispName as BranchName, dispatch.sno FROM dispatch INNER JOIN branchdata ON dispatch.Branch_Id = branchdata.sno INNER JOIN branchdata branchdata_1 ON dispatch.Branch_Id = branchdata_1.sno WHERE ((branchdata.sno = @BranchID) and (dispatch.flag=@flag)) OR ((branchdata_1.SalesOfficeID = @SOID) and (dispatch.flag=@flag))");
                    cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                    cmd.Parameters.Add("@SOID", context.Session["branch"]);
                    cmd.Parameters.Add("@flag", "1");
                    dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM  branchdata INNER JOIN branchdata branchdata_1 ON branchdata.sno = branchdata_1.sno WHERE (branchdata_1.SalesOfficeID = @SOID) AND (branchdata.SalesType IS NOT NULL) OR (branchdata.sno = @BranchID) AND (branchdata.SalesType IS NOT NULL)");
                    //cmd = new MySqlCommand("SELECT BranchName, sno FROM branchdata WHERE (sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                    cmd.Parameters.Add("@SOID", context.Session["branch"]);
                    dtRoutedata = vdm.SelectQuery(cmd).Tables[0];
                }
                List<Route> Routelist = new List<Route>();
                foreach (DataRow dr in dtRoutedata.Rows)
                {
                    Route b = new Route() { rid = dr["sno"].ToString(), RouteName = dr["BranchName"].ToString(), Branchid = context.Session["branch"].ToString() };
                    Routelist.Add(b);
                }
                string response = GetJson(Routelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        public class emplogin
        {
            public string LevelType { get; set; }
            public string valid { get; set; }
            public string UserSno { get; set; }
            public string userdata_sno { get; set; }
            public string UserName { get; set; }
            public string EmpName { get; set; }
            public string branch { get; set; }
            public string branchname { get; set; }
            public string salestype { get; set; }
        }
        private void emp_login_click(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string username = context.Request["username"];
                string password = context.Request["password"];
                context.Session["username"] = username;
                context.Session["password"] = password;
                cmd = new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName, empmanage.Password, empmanage.LevelType, empmanage.flag, empmanage.Userdata_sno, empmanage.Owner, empmanage.EmpName, empmanage.Address, empmanage.Mobno, empmanage.Email, empmanage.LWC, empmanage.RefName, empmanage.Dept_Sno, branchdata.BranchName, empmanage.Branch, salestypemanagement.salestype FROM empmanage INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                //cmd=new MySqlCommand("SELECT empmanage.Sno, empmanage.UserName, empmanage.Password, empmanage.LevelType,empmanage.flag, empmanage.Userdata_sno, empmanage.Owner, empmanage.EmpName, empmanage.Address, empmanage.Mobno, empmanage.Email, empmanage.LWC, empmanage.RefName, empmanage.Dept_Sno, branchdata.BranchName,branchdata.SalesType, empmanage.Branch FROM empmanage INNER JOIN branchdata ON empmanage.Branch = branchdata.sno WHERE (empmanage.UserName = @UN) AND (empmanage.Password = @Pwd)");
                //cmd = new MySqlCommand("select * from empmanage where UserName=@UN and Password=@Pwd");
                cmd.Parameters.Add("@UN", username);
                cmd.Parameters.Add("@Pwd", password);
                DataTable dtemp = vdm.SelectQuery(cmd).Tables[0];
                List<emplogin> emploginlist = new List<emplogin>();
                if (dtemp.Rows.Count > 0)
                {
                    emplogin obj1 = new emplogin();
                    cmd = new MySqlCommand("SELECT branchmappingtable.SuperBranch, branchdata.BranchName, branchdata.stateid, branchdata.gstno, branchdata.statename, statemastar.statename AS BranchState, statemastar.gststatecode FROM branchmappingtable INNER JOIN empmanage ON branchmappingtable.SubBranch = empmanage.Branch INNER JOIN branchdata ON empmanage.Branch = branchdata.sno INNER JOIN statemastar ON branchdata.stateid = statemastar.sno WHERE (empmanage.UserName = @UN)");
                    //cmd = new MySqlCommand("SELECT branchmappingtable.SuperBranch FROM branchmappingtable INNER JOIN empmanage ON branchmappingtable.SubBranch = empmanage.Branch WHERE (empmanage.UserName = @UN)");
                    cmd.Parameters.Add("@UN", username);
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    string PlantID = "";
                    string Branch = dtemp.Rows[0]["Branch"].ToString();
                    if (dtBranch.Rows.Count > 0)
                    {
                        PlantID = dtBranch.Rows[0]["SuperBranch"].ToString();
                        if (PlantID == "172" || Branch == "172" || PlantID == "1801" || Branch == "1801" || Branch == "3625" || Branch == "3919")
                        {
                            context.Session["TitleName"] = "SRI VYSHNAVI DAIRY SPECIALITIES (P) LTD";
                            context.Session["Address"] = "R.S.No:381/2,Punabaka village Post,Pellakuru Mandal,Nellore District -524129., ANDRAPRADESH (State).Phone: 9440622077, Fax: 044 – 26177799.";
                            context.Session["TinNo"] = "37921042267";
                        }
                        else
                        {
                            context.Session["TitleName"] = "SRI VYSHNAVI FOODS (P) LTD";
                            context.Session["Address"] = " Near Ayyappa Swamy Temple, Shasta Nagar, WYRA-507165,KHAMMAM (District), TELANGANA (State).Phone: 08749 – 251326, Fax: 08749 – 252198.";
                            context.Session["TinNo"] = "36550160129";
                        }
                        context.Session["BranchName"] = dtBranch.Rows[0]["BranchName"].ToString();
                    }
                    string LevelType = dtemp.Rows[0]["LevelType"].ToString();
                    obj1.LevelType = LevelType;
                    obj1.valid = "Valid";
                    context.Session["gstin"] = dtBranch.Rows[0]["gstno"].ToString();
                    context.Session["statename"] = dtBranch.Rows[0]["BranchState"].ToString();
                    context.Session["statecode"] = dtBranch.Rows[0]["gststatecode"].ToString();
                    context.Session["stateid"] = dtBranch.Rows[0]["stateid"].ToString();


                    string ModuleId = "1";
                    context.Session["moduleid"] = ModuleId;
                    context.Session["UserSno"] = dtemp.Rows[0]["Sno"].ToString();
                    context.Session["userdata_sno"] = dtemp.Rows[0]["UserData_sno"].ToString();
                    context.Session["UserName"] = dtemp.Rows[0]["UserName"].ToString();
                    context.Session["EmpName"] = dtemp.Rows[0]["EmpName"].ToString();
                    context.Session["LevelType"] = dtemp.Rows[0]["LevelType"].ToString();
                    context.Session["branch"] = dtemp.Rows[0]["Branch"].ToString();
                    context.Session["branchname"] = dtemp.Rows[0]["BranchName"].ToString();
                    context.Session["salestype"] = dtemp.Rows[0]["salestype"].ToString();
                    //context.Session["salestype"] = dtemp.Rows[0]["salestype"].ToString();
                    string UserSno = dtemp.Rows[0]["Sno"].ToString();
                    obj1.UserSno = UserSno;
                    string userdata_sno = dtemp.Rows[0]["UserData_sno"].ToString();
                    obj1.userdata_sno = userdata_sno;
                    string UserName = dtemp.Rows[0]["UserName"].ToString();
                    obj1.UserName = UserName;
                    string EmpName = dtemp.Rows[0]["EmpName"].ToString();
                    obj1.EmpName = EmpName;
                    string branch = dtemp.Rows[0]["Branch"].ToString();
                    obj1.branch = Branch;
                    string branchname = dtemp.Rows[0]["BranchName"].ToString();
                    obj1.UserSno = UserSno;
                    string salestype = dtemp.Rows[0]["salestype"].ToString();
                    obj1.UserSno = UserSno;
                    emploginlist.Add(obj1);
                    string response = GetJson(emploginlist);
                    context.Response.Write(response);
                }
                else
                {
                    string response = GetJson("Not Valid");
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string response = GetJson("Error");
                context.Response.Write(response);
            }
        }

        public class Orderclass
        {
            public string HdnSno { set; get; }
            public string sno { set; get; }
            public string ProductCode { set; get; }
            public string Productsno { set; get; }
            public double Qty { set; get; }
            public float Rate { set; get; }
            public double Total { set; get; }
            public string Status { set; get; }
            public string IndentNo { set; get; }
            public string Units { set; get; }
            public string Unitqty { set; get; }
            public string Desciption { set; get; }
            public string orderunitqty { set; get; }
            public float orderunitRate { set; get; }
            public double LeakQty { set; get; }
            public double DQty { set; get; }
            public double RQty { set; get; }
            public double TRQty { set; get; }
            public double PrevQty { set; get; }
            public double returnqty { set; get; }
        }
        public class redirecturl
        {
            public string responseurl { set; get; }
        }
        private static string GetJson(object obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Serialize(obj);
        }
        public class SoClass
        {
            public string BranchName { get; set; }
            public string Sno { get; set; }
            public string Salestype { get; set; }
            public string color { get; set; }
            public string ExpencePeriod { get; set; }
            public string mobile { get; set; }
            public string routeid { get; set; }
        }
        private void GetSalesOffice(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string SalesType = context.Session["salestype"].ToString();
                List<SoClass> Solist = new List<SoClass>();
                if (SalesType == "Plant")
                {
                    cmd = new MySqlCommand("SELECT branchdata.sno, branchdata.BranchName FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno where  (branchmappingtable.SuperBranch=@BranchID) AND (branchdata.SALESTYPE=@st)");
                    cmd.Parameters.Add("@st", "21");
                    cmd.Parameters.Add("@BranchId", context.Session["branch"].ToString());
                    DataTable dtBranch = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtBranch.Rows)
                    {
                        SoClass GetSoClass = new SoClass();
                        GetSoClass.Sno = dr["sno"].ToString();
                        GetSoClass.BranchName = dr["BranchName"].ToString();
                        Solist.Add(GetSoClass);
                    }
                    cmd = new MySqlCommand("SELECT BranchName, sno FROM  branchdata WHERE (sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                    DataTable dtPlant = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtPlant.Rows)
                    {
                        SoClass GetSoClass = new SoClass();
                        GetSoClass.Sno = dr["sno"].ToString();
                        GetSoClass.BranchName = dr["BranchName"].ToString();
                        Solist.Add(GetSoClass);
                    }
                    cmd = new MySqlCommand("SELECT branchdata.BranchName, branchdata.sno FROM branchdata INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @SuperBranch) and (branchdata.SalesType=@SalesType)  ");
                    cmd.Parameters.Add("@SuperBranch", context.Session["branch"].ToString());
                    cmd.Parameters.Add("@SalesType", "23");
                    DataTable dtNewPlant = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtNewPlant.Rows)
                    {
                        SoClass GetSoClass = new SoClass();
                        GetSoClass.Sno = dr["sno"].ToString();
                        GetSoClass.BranchName = dr["BranchName"].ToString();
                        Solist.Add(GetSoClass);
                    }

                    string errresponse = GetJson(Solist);
                    context.Response.Write(errresponse);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT BranchName, sno FROM  branchdata WHERE (sno = @BranchID)");
                    cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                    DataTable dtPlant = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtPlant.Rows)
                    {
                        SoClass GetSoClass = new SoClass();
                        GetSoClass.Sno = dr["sno"].ToString();
                        GetSoClass.BranchName = dr["BranchName"].ToString();
                        Solist.Add(GetSoClass);
                    }
                    string errresponse = GetJson(Solist);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        private void Getsessionvalues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<emplogin> sessionlist = new List<emplogin>();
                emplogin sessionvalue = new emplogin();
                sessionvalue.LevelType = context.Session["LevelType"].ToString();
                sessionvalue.EmpName = context.Session["EmpName"].ToString();
                sessionlist.Add(sessionvalue);
                string msg = GetJson(sessionlist);
                context.Response.Write(msg);
            }
            catch (Exception ex)
            {
                string response = GetJson("Error");
                context.Response.Write(response);
            }
        }
        private DateTime GetLowDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            DT = dt;
            Hour = -dt.Hour;
            Min = -dt.Minute;
            Sec = -dt.Second;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;

        }
        private DateTime GetHighDate(DateTime dt)
        {
            double Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            Hour = 23 - dt.Hour;
            Min = 59 - dt.Minute;
            Sec = 59 - dt.Second;
            DT = dt;
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;
        }
        private void VoucherReject(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string VoucherID = context.Request["VoucherID"];
                string Approvalamt = context.Request["Approvalamt"];
                string Remarks = context.Request["Remarks"];
                string Status = context.Request["Status"];
                string AppRemarks = context.Request["AppRemarks"];
                string BranchID = "0";
                string LevelType = context.Session["LevelType"].ToString();
                if (LevelType == "AccountsOfficer" || LevelType == "Director")
                {
                    BranchID = context.Request["BranchID"];
                }
                else
                {
                    BranchID = context.Session["branch"].ToString();
                }
                cmd = new MySqlCommand("Update cashpayables set  Remarks=@Remarks,ApprovedAmount=@ApprovedAmount ,ApprovalRemarks=@ApprovalRemarks,Status=@Status where  Sno=@VocherID and BranchID=@BranchID ");
                cmd.Parameters.Add("@Status", Status);
                cmd.Parameters.Add("@ApprovedAmount", Approvalamt);
                cmd.Parameters.Add("@ApprovalRemarks", AppRemarks);
                cmd.Parameters.Add("@VocherID", VoucherID);
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@Remarks", Remarks);
                vdm.Update(cmd);
                string msg = "Voucher Reject successfully";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void VoucherApproval(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string VoucherID = context.Request["VoucherID"];
                string Approvalamt = context.Request["Approvalamt"];
                double Amount = 0;
                double.TryParse(Approvalamt, out Amount);
                string Remarks = context.Request["Remarks"];
                string AppRemarks = context.Request["AppRemarks"];
                string Status = context.Request["Status"];
                string BranchID = "0";
                string LevelType = context.Session["LevelType"].ToString();
                if (LevelType == "AccountsOfficer" || LevelType == "Director")
                {
                    BranchID = context.Request["BranchID"];
                }
                else
                {
                    BranchID = context.Session["branch"].ToString();
                }
                DateTime ServerDateCurrentdate = VehicleDBMgr.GetTime(vdm.conn);
                cmd = new MySqlCommand("SELECT Branchid, UserData_sno, AmountPaid, Denominations, Remarks, Sno, PaidDate FROM collections WHERE (Branchid = @BranchID) AND (PaidDate BETWEEN @d1 AND @d2)");
                cmd.Parameters.Add("@BranchID", BranchID);
                cmd.Parameters.Add("@d1", GetLowDate(ServerDateCurrentdate));
                cmd.Parameters.Add("@d2", GetHighDate(ServerDateCurrentdate));
                DataTable dtcashbookstatus = vdm.SelectQuery(cmd).Tables[0];
                if (dtcashbookstatus.Rows.Count > 0)
                {
                    string msg = "Cash Book Closed For This Day";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("Update cashpayables set Remarks=@Remarks,DOE=@DOE, ApprovedAmount=@ApprovedAmount ,ApprovalRemarks=@ApprovalRemarks,Status=@Status where Sno=@VocherID and BranchID=@BranchID");
                    cmd.Parameters.Add("@Status", Status);
                    cmd.Parameters.Add("@ApprovedAmount", Amount);
                    cmd.Parameters.Add("@ApprovalRemarks", AppRemarks);
                    cmd.Parameters.Add("@Remarks", Remarks);
                    cmd.Parameters.Add("@VocherID", VoucherID);
                    cmd.Parameters.Add("@BranchID", BranchID);
                    cmd.Parameters.Add("@DOE", ServerDateCurrentdate);
                    vdm.Update(cmd);
                    string msg = "Voucher Approved successfully";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        private void Get_RaisedVoucherdetails(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                List<VoucherClass> Voucherlist = new List<VoucherClass>();
                string LevelType = context.Session["LevelType"].ToString();
                string status = "R";
                string fromdate = context.Request["fromdate"];
                string ToDate = context.Request["ToDate"];
                DateTime dtFromdate = Convert.ToDateTime(fromdate);
                DateTime dtTodate = Convert.ToDateTime(ToDate);
                if (LevelType == "Manager")
                {
                    //cmd = new MySqlCommand("SELECT cashpayables.Sno, cashpayables.Empid,empmanage.EmpName, cashpayables.VocherID, cashpayables.Amount FROM cashpayables INNER JOIN empmanage ON cashpayables.Empid = empmanage.Sno WHERE (cashpayables.BranchID = @BranchID) AND (cashpayables.Status = @Status)");
                    cmd = new MySqlCommand("SELECT cashpayables.Sno,cashpayables.onNameof, cashpayables.Empid,cashpayables.VoucherType, empmanage.EmpName, cashpayables.VocherID, cashpayables.Amount, cashpayables.Remarks,cashpayables.onNameof FROM cashpayables LEFT OUTER JOIN empmanage ON cashpayables.Empid = empmanage.Sno WHERE (cashpayables.BranchID = @BranchID) AND (cashpayables.Status = @Status) and (cashpayables.Approvedby=@ApproveEmp)");
                    cmd.Parameters.Add("@ApproveEmp", context.Session["UserSno"].ToString());
                    cmd.Parameters.Add("@BranchID", context.Session["branch"].ToString());
                    cmd.Parameters.Add("@Status", "R");
                }
                if (LevelType == "AccountsOfficer" || LevelType == "Director")
                {
                    string BranchID = context.Request["BranchID"];
                    if (status == "R")
                    {
                        cmd = new MySqlCommand("SELECT cashpayables.VocherID,cashpayables.Sno,cashpayables.onNameof, cashpayables.Empid,cashpayables.VoucherType, empmanage.EmpName, cashpayables.VocherID, cashpayables.Amount, cashpayables.Remarks,cashpayables.onNameof FROM cashpayables LEFT OUTER JOIN empmanage ON cashpayables.Empid = empmanage.Sno WHERE (cashpayables.Status = @Status) AND (cashpayables.BranchID = @BranchID)");
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT cashpayables.VocherID,cashpayables.Sno, cashpayables.onNameof, cashpayables.Empid, cashpayables.VoucherType, empmanage.EmpName, cashpayables.VocherID,cashpayables.Amount, cashpayables.Remarks FROM cashpayables LEFT OUTER JOIN empmanage ON cashpayables.Empid = empmanage.Sno WHERE (cashpayables.Status = @Status) AND (cashpayables.BranchID = @BranchID) AND (cashpayables.DOE BETWEEN @d1 AND @d2) AND (cashpayables.VoucherType <> @vtype)");
                    }
                    cmd.Parameters.Add("@BranchID", BranchID);
                    cmd.Parameters.Add("@d1", GetLowDate(dtFromdate));
                    cmd.Parameters.Add("@d2", GetHighDate(dtTodate));
                    cmd.Parameters.Add("@vtype", "Credit");
                    cmd.Parameters.Add("@Status", status);
                }
                DataTable dtVoucher = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtVoucher.Rows)
                {
                    VoucherClass getVoucher = new VoucherClass();
                    getVoucher.branchvocherid = dr["VocherID"].ToString();
                    getVoucher.VoucherID = dr["sno"].ToString();
                    getVoucher.EmpName = dr["onNameof"].ToString();
                    getVoucher.VoucherType = dr["VoucherType"].ToString();
                    getVoucher.Amount = dr["Amount"].ToString();
                    getVoucher.Empid = dr["Empid"].ToString();
                    getVoucher.Sno = dr["Sno"].ToString();
                    Voucherlist.Add(getVoucher);
                }
                string response = GetJson(Voucherlist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class VoucherClass
        {
            public string VoucherID { get; set; }
            public string EmpName { get; set; }
            public string Amount { get; set; }
            public string Empid { get; set; }
            public string Sno { get; set; }
            public string ApproveEmpName { get; set; }
            public string VoucherType { get; set; }
            public string CashTo { get; set; }
            public string Description { get; set; }
            public string ApprovalRemarks { get; set; }
            public string ApprovalAmount { get; set; }
            public string Status { get; set; }
            public string Remarks { get; set; }
            public string ApprovedBy { get; set; }
            public string AccountType { get; set; }
            public string BranchID { get; set; }
            public string branchvocherid { get; set; }
        }
        private void GetBtnViewVoucherclick(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string VoucherID = context.Request["VoucherID"];
                string BranchID = "0";
                string LevelType = context.Session["LevelType"].ToString();
                if (LevelType == "AccountsOfficer" || LevelType == "Director")
                {
                    BranchID = context.Request["BranchID"];
                }
                else
                {
                    BranchID = context.Session["branch"].ToString();
                }
                List<VoucherClass> Voucherlist = new List<VoucherClass>();
                //cmd = new MySqlCommand("SELECT empmanage.EmpName,cashpayables.EmpID,cashpayables.Approvedby, cashpayables.VoucherType, cashpayables.CashTo, cashpayables.onNameof, cashpayables.Amount, cashpayables.ApprovedAmount, empmanage_1.EmpName AS ApproveEmpName, cashpayables.Status, cashpayables.ApprovalRemarks, cashpayables.Remarks FROM empmanage INNER JOIN cashpayables ON empmanage.Sno = cashpayables.Empid INNER JOIN empmanage empmanage_1 ON cashpayables.Approvedby = empmanage_1.Sno WHERE (cashpayables.VocherID = @VoucherID) AND (cashpayables.BranchID = @BranchID)");
                cmd = new MySqlCommand("SELECT  empmanage.EmpName,cashpayables.Empid, cashpayables.Approvedby, cashpayables.VoucherType, cashpayables.CashTo, cashpayables.onNameof, cashpayables.Amount, cashpayables.ApprovedAmount, empmanage_1.EmpName AS ApproveEmpName, cashpayables.Status, cashpayables.ApprovalRemarks, cashpayables.Remarks FROM empmanage empmanage_1 INNER JOIN cashpayables ON empmanage_1.Sno = cashpayables.Approvedby LEFT OUTER JOIN empmanage ON cashpayables.Empid = empmanage.Sno WHERE (cashpayables.Sno = @VoucherID) AND (cashpayables.BranchID = @BranchID)");
                cmd.Parameters.Add("@VoucherID", VoucherID);
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtVouchers = vdm.SelectQuery(cmd).Tables[0];
                if (dtVouchers.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtVouchers.Rows)
                    {
                        VoucherClass getVoucher = new VoucherClass();
                        getVoucher.EmpName = dr["EmpName"].ToString();
                        getVoucher.VoucherType = dr["VoucherType"].ToString();
                        getVoucher.CashTo = dr["CashTo"].ToString();
                        getVoucher.Description = dr["onNameof"].ToString();
                        getVoucher.Amount = dr["Amount"].ToString();
                        getVoucher.ApprovalAmount = dr["ApprovedAmount"].ToString();
                        getVoucher.ApproveEmpName = dr["ApproveEmpName"].ToString();
                        getVoucher.Status = dr["Status"].ToString();
                        getVoucher.ApprovalRemarks = dr["ApprovalRemarks"].ToString();
                        getVoucher.Remarks = dr["Remarks"].ToString();
                        getVoucher.Empid = dr["EmpID"].ToString();
                        getVoucher.ApprovedBy = dr["Approvedby"].ToString();
                        Voucherlist.Add(getVoucher);
                    }
                    string response = GetJson(Voucherlist);
                    context.Response.Write(response);
                }
                else
                {
                    string msg = "voucher is No found";
                    string response = GetJson(msg);
                    context.Response.Write(response);
                }
            }
            catch
            {
            }
        }
        class Subpayables
        {
            public string HeadSno { get; set; }
            public string HeadOfAccount { get; set; }
            public string Amount { get; set; }
        }
        private void GetAppriveSubPaybleValues(HttpContext context)
        {

            try
            {
                vdm = new VehicleDBMgr();
                string VoucherID = context.Request["VoucherID"];
                List<Subpayables> SubpayableList = new List<Subpayables>();
                string BranchID = "0";
                string LevelType = context.Session["LevelType"].ToString();
                if (LevelType == "AccountsOfficer" || LevelType == "Director")
                {
                    BranchID = context.Request["BranchID"];
                }
                else
                {
                    BranchID = context.Session["branch"].ToString();
                }
                cmd = new MySqlCommand("SELECT Sno FROM cashpayables WHERE (Sno = @VocherID) AND (BranchID = @BranchID)");
                cmd.Parameters.Add("@VocherID", VoucherID);
                cmd.Parameters.Add("@BranchID", BranchID);
                DataTable dtCash = vdm.SelectQuery(cmd).Tables[0];
                string RefNo = dtCash.Rows[0]["Sno"].ToString();
                cmd = new MySqlCommand("SELECT accountheads.HeadName, subpayable.Amount, accountheads.Sno FROM subpayable INNER JOIN accountheads ON subpayable.HeadSno = accountheads.Sno WHERE (subpayable.RefNo = @RefNo)");
                cmd.Parameters.Add("@RefNo", RefNo);
                DataTable dtCashSubPayable = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtCashSubPayable.Rows)
                {
                    Subpayables GetSubpayable = new Subpayables();
                    GetSubpayable.HeadSno = dr["Sno"].ToString();
                    GetSubpayable.HeadOfAccount = dr["HeadName"].ToString();
                    GetSubpayable.Amount = dr["Amount"].ToString();
                    SubpayableList.Add(GetSubpayable);
                }
                string response = GetJson(SubpayableList);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        //private void VoucherUpdate(HttpContext context)
        //{
        //    try
        //    {
        //        vdm = new VehicleDBMgr();
        //        string VoucherID = context.Request["VoucherID"];
        //        string Remarks = context.Request["Remarks"];
        //        string BranchID = "0";
        //        string LevelType = context.Session["LevelType"].ToString();
        //        if (LevelType == "AccountsOfficer" || LevelType == "Director")
        //        {
        //            BranchID = context.Request["BranchID"];
        //        }
        //        else
        //        {
        //            BranchID = context.Session["branch"].ToString();
        //        }
        //        cmd = new MySqlCommand("Update cashpayables set Ramarks=@Ramarks where BranchID=@BranchID and Sno=@VocherID");
        //        cmd.Parameters.Add("@VocherID", VoucherID);
        //        cmd.Parameters.Add("@Remarks", Remarks);
        //        cmd.Parameters.Add("@BranchID", BranchID);
        //       // vdm.Update(cmd);
        //        string msg = "Voucher Updated successfully";
        //        string response = GetJson(msg);
        //        context.Response.Write(response);
        //    }
        //    catch
        //    {
        //    }
        //}
        private void log_out(HttpContext context)
        {
            try
            {
                context.Session["UserSno"] = null;
                context.Session["userdata_sno"] = null;
                context.Session["UserName"] = null;
                context.Session["EmpName"] = null;
                context.Session["LevelType"] = null;
                context.Session["branch"] = null;
                context.Session["branchname"] = null;
                context.Session["salestype"] = null;
                context.Session.Abandon();
                context.Session.RemoveAll();
                context.Session.Clear();
                string msg = "Valid";
                string response = GetJson(msg);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string response = GetJson("Error");
                context.Response.Write(response);
            }
        }

        class LekageData
        {
            public string IndentDate { get; set; }
            public string Price { get; set; }
            public string productname { get; set; }
            public string leakqty { get; set; }
            public string status { get; set; }
            public string totalleaks { get; set; }
            public string totalleakqty { get; set; }
        }
        private void Get_lekage_details(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DataTable dtlekageData = new DataTable();
                string RouteID = "";
                string Date = context.Request["Date"];
                // RouteID = context.Request["RouteID"];
                string Branchid = context.Request["Branchid"].ToString();
                DateTime date = Convert.ToDateTime(Date);
                if (context.Session["IndentData"] == null)
                {

                    cmd = new MySqlCommand("SELECT   SUM(result.LeakQty) AS TotalLeaks, result.ProductName, result.DispName, result.Categoryname, result.Prodsno AS productid FROM  (SELECT  SUM(Leaks.TotalLeaks) AS LeakQty, Leaks.ProductName, Leaks.Categoryname, ff.DispName, Leaks.Prodsno FROM  (SELECT leakages.TotalLeaks, productsdata.ProductName, tripdata_1.Sno, products_category.Categoryname, productsdata.sno AS Prodsno FROM  tripdata tripdata_1 INNER JOIN leakages ON tripdata_1.Sno = leakages.TripID INNER JOIN productsdata ON leakages.ProductID = productsdata.sno INNER JOIN products_subcategory ON productsdata.SubCat_sno = products_subcategory.sno INNER JOIN products_category ON products_subcategory.category_sno = products_category.sno WHERE (leakages.VarifyStatus = 'V') AND (tripdata_1.I_Date BETWEEN @d1 AND @d2)) Leaks INNER JOIN (SELECT DispName, Sno, DespSno FROM  (SELECT dispatch.DispName, tripdata.Sno, dispatch.sno AS DespSno FROM branchdata INNER JOIN dispatch ON branchdata.sno = dispatch.Branch_Id INNER JOIN triproutes ON dispatch.sno = triproutes.RouteID INNER JOIN tripdata ON triproutes.Tripdata_sno = tripdata.Sno WHERE (tripdata.I_Date BETWEEN @d1 AND @d2) AND (dispatch.Branch_Id = @BranchID)) TripInfo) ff ON ff.Sno = Leaks.Sno GROUP BY Leaks.ProductName, ff.DespSno) result INNER JOIN (SELECT branch_sno, product_sno, Rank FROM  branchproducts WHERE (branch_sno = @BranchID)) brnchproductsRank ON result.Prodsno = brnchproductsRank.product_sno GROUP BY result.Prodsno");
                    cmd.Parameters.Add("@branchid", Branchid);
                    cmd.Parameters.Add("@d1", GetLowDate(date).AddDays(-1));
                    cmd.Parameters.Add("@d2", GetHighDate(date).AddDays(-1));
                    dtlekageData = vdm.SelectQuery(cmd).Tables[0];
                }
                else
                {
                    context.Session["LekageData"] = dtlekageData;
                }
                List<LekageData> lekagedetailslist = new List<LekageData>();
                if (dtlekageData.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtlekageData.Rows)
                    {
                        LekageData getlekage = new LekageData();
                        //getlekage.IndentDate = dr["I_Date"].ToString();
                        getlekage.productname = dr["ProductName"].ToString();
                        string leakqty = dr["TotalLeaks"].ToString();
                        double qty = 0;
                        double.TryParse(leakqty, out qty);
                        qty = Math.Round(qty, 2);
                        getlekage.totalleakqty = qty.ToString();
                        lekagedetailslist.Add(getlekage);
                    }
                }
                string response = GetJson(lekagedetailslist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        class DcNumbers
        {
            public string DcNumber { get; set; }
            public string branch { get; set; }
            public string ProductName { get; set; }
            public string crates { get; set; }
            public string qty { get; set; }
            public string balanceamount { get; set; }
            public string totalinvqty { get; set; }

        }
        private void GetDCNumbers(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string FromDate = context.Request["fromdate"];
                DateTime fromdate = Convert.ToDateTime(FromDate);
                string tdate = context.Request["todate"];
                DateTime Todate = Convert.ToDateTime(tdate);
                if (context.Session["salestype"].ToString() == "Plant")
                {
                    cmd = new MySqlCommand("SELECT tripdata.Sno AS Dcnumber,dispatch.DispName   FROM tripdata INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno WHERE (tripdata.Status <> 'c') and (tripdata.DespatchStatus=@DespatchStatus) AND (tripdata.AssignDate BETWEEN @Adt AND @Adt1) AND (tripdata.Permissions LIKE '%D%') AND (dispatch.Branch_Id = @brnch)");
                    cmd.Parameters.Add("@DespatchStatus", "Yes");
                    cmd.Parameters.Add("@brnch", context.Session["branch"]);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT  tripdata.Sno AS Dcnumber,dispatch.dispname FROM  tripdata INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno WHERE (tripdata.Status <> 'c') AND (tripdata.AssignDate BETWEEN @Adt AND @Adt1) AND (tripdata.Permissions LIKE '%D%') AND (empmanage.Branch = @brnch) OR (tripdata.Status <> 'c') AND (tripdata.AssignDate BETWEEN @Adt AND @Adt1) AND (tripdata.Permissions LIKE '%D%') AND (branchdata.SalesOfficeID = @SOID)");
                    //cmd = new MySqlCommand("SELECT tripdata.Sno AS Dcnumber FROM tripdata INNER JOIN empmanage ON tripdata.EmpId = empmanage.Sno INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno INNER JOIN branchdata ON empmanage.Branch = branchdata.sno WHERE (tripdata.Status = 'c') AND (tripdata.AssignDate BETWEEN @Adt AND @Adt1) AND (tripdata.Permissions LIKE '%D%') AND (empmanage.Branch = @brnch) OR (tripdata.Status = 'c') AND (tripdata.AssignDate BETWEEN @Adt AND @Adt1) AND (tripdata.Permissions LIKE '%D%') AND (branchdata.SalesOfficeID = @SOID)");
                    cmd.Parameters.Add("@brnch", context.Session["branch"]);
                    cmd.Parameters.Add("@SOID", context.Session["branch"]);
                }
                cmd.Parameters.Add("@Adt", GetLowDate(fromdate));
                cmd.Parameters.Add("@Adt1", GetHighDate(Todate));
                List<DcNumbers> dcnumberslist = new List<DcNumbers>();
                DataTable dttripdata = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dttripdata.Rows)
                {
                    DcNumbers o = new DcNumbers();
                    o.DcNumber = dr["Dcnumber"].ToString();
                    o.branch = dr["DispName"].ToString();
                    dcnumberslist.Add(o);
                }
                string response = GetJson(dcnumberslist);
                context.Response.Write(response);
            }
            catch
            {

            }
        }
        private void GetDCDetails(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string dcno = context.Request["dcno"];
                cmd = new MySqlCommand("SELECT tripdata.BranchID, tripdata.AssignDate, tripdata.Sno, tripdata.DCNo, tripdata.DispTime, tripdata.VehicleNo, dispatch.DispMode, dispatch.DispName AS DispatchName, dispatch.sno AS dispsno, empmanage_1.EmpName AS Employee, empmanage.EmpName AS dispather FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN dispatch ON triproutes.RouteID = dispatch.sno LEFT OUTER JOIN empmanage ON tripdata.DEmpId = empmanage.Sno LEFT OUTER JOIN empmanage empmanage_1 ON tripdata.EmpId = empmanage_1.Sno WHERE (tripdata.Sno = @dcno)");
                cmd.Parameters.Add("@dcno", dcno);
                DataTable dtdispatchdetals = vdm.SelectQuery(cmd).Tables[0];
                string desno = dtdispatchdetals.Rows[0]["dispsno"].ToString();
                cmd = new MySqlCommand("SELECT sno, DispName, BranchID, Dispdate, DispMode,DispType FROM dispatch WHERE (sno = @DispSno)");
                cmd.Parameters.Add("@DispSno", desno);
                DataTable dtdespatchbranch = vdm.SelectQuery(cmd).Tables[0];
                string branchid = dtdespatchbranch.Rows[0]["BranchID"].ToString();
                string salestype = context.Session["salestype"].ToString();
                if (salestype == "SALES OFFICE")
                {
                    branchid = context.Session["branch"].ToString();
                }
                cmd = new MySqlCommand("SELECT tripsubdata.ProductId, productsdata.ProductName, productsdata.VatPercent, branchproducts.VatPercent AS vp, tripsubdata.Price, ROUND(tripsubdata.Qty, 2) AS Qty,tripdata.AssignDate, tripdata.BranchID, branchproducts_1.VatPercent AS plantvp FROM tripdata INNER JOIN triproutes ON tripdata.Sno = triproutes.Tripdata_sno INNER JOIN tripsubdata ON tripdata.Sno = tripsubdata.Tripdata_sno INNER JOIN productsdata ON tripsubdata.ProductId = productsdata.sno INNER JOIN branchproducts ON productsdata.sno = branchproducts.product_sno INNER JOIN branchproducts branchproducts_1 ON tripdata.BranchID = branchproducts_1.branch_sno AND branchproducts.product_sno = branchproducts_1.product_sno WHERE (tripdata.Sno = @dcno) AND (branchproducts.branch_sno = @BranchID) GROUP BY productsdata.ProductName ORDER BY branchproducts.Rank");
                cmd.Parameters.Add("@dcno", dcno);
                cmd.Parameters.Add("@BranchID", branchid);
                DataTable dtproductsdata = vdm.SelectQuery(cmd).Tables[0];
                cmd = new MySqlCommand("SELECT invmaster.InvName, tripinvdata.Qty FROM tripinvdata INNER JOIN invmaster ON tripinvdata.invid = invmaster.sno WHERE (tripinvdata.Tripdata_sno = @dcno)");
                cmd.Parameters.Add("@dcno", dcno);
                DataTable dtinventarydata = vdm.SelectQuery(cmd).Tables[0];
                string totalinvqty = dtinventarydata.Rows[0]["Qty"].ToString();
                double invqty = 0;
                double.TryParse(totalinvqty, out invqty);
                List<DcNumbers> dcnumberdetailslist = new List<DcNumbers>();
                if (dtproductsdata.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtproductsdata.Rows)
                    {
                        DcNumbers getdcitemsdata = new DcNumbers();
                        getdcitemsdata.ProductName = dr["ProductName"].ToString();
                        getdcitemsdata.qty = dr["Qty"].ToString();
                        string Qty = dr["Qty"].ToString();
                        double qty = 0;
                        double.TryParse(Qty, out qty);
                        double invcrates = qty / 12;
                        double invquantity = Math.Round(invcrates, 0);
                        getdcitemsdata.crates = invquantity.ToString();
                        dcnumberdetailslist.Add(getdcitemsdata);
                    }
                }
                string response = GetJson(dcnumberdetailslist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void get_ClosingStock_Items(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string branchid = context.Request["branchid"];
                string FromDate = context.Request["fromdate"];
                DateTime fromdate = Convert.ToDateTime(FromDate);
                //inventary// cmd = new MySqlCommand("SELECT  productsdata.ProductName, closubtranprodcts.StockQty, productsdata.sno FROM clotrans INNER JOIN closubtranprodcts ON clotrans.Sno = closubtranprodcts.RefNo INNER JOIN productsdata ON closubtranprodcts.ProductID = productsdata.sno WHERE (clotrans.IndDate BETWEEN @d1 AND @d2) AND (clotrans.BranchId = @BranchID) GROUP BY productsdata.ProductName");
                cmd = new MySqlCommand("SELECT productsdata.ProductName,productsdata.sno, branchproducts.BranchQty AS StockQty, branchproducts.LeakQty FROM branchproducts INNER JOIN productsdata ON branchproducts.product_sno = productsdata.sno WHERE (branchproducts.branch_sno = @BranchID) AND branchproducts.BranchQty >0 GROUP BY productsdata.ProductName Order by branchproducts.Rank");
                cmd.Parameters.Add("@d1", GetLowDate(fromdate).AddDays(-1));
                cmd.Parameters.Add("@d2", GetLowDate(fromdate));
                cmd.Parameters.Add("@BranchID", branchid);
                List<DcNumbers> getbalnaceitemslist = new List<DcNumbers>();
                DataTable dtbalqty = vdm.SelectQuery(cmd).Tables[0];
                foreach (DataRow dr in dtbalqty.Rows)
                {
                    DcNumbers getbalnaceitems = new DcNumbers();
                    getbalnaceitems.ProductName = dr["ProductName"].ToString();
                    getbalnaceitems.qty = dr["StockQty"].ToString();
                    getbalnaceitemslist.Add(getbalnaceitems);
                }
                string response = GetJson(getbalnaceitemslist);
                context.Response.Write(response);
            }
            catch
            {

            }
        }
        private void get_Balance_Amount(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Agentid = context.Request["Agentid"];
                string Routeid = context.Request["Routeid"];
                string leveltype = context.Session["LevelType"].ToString();
                DataTable dtbalqty = new DataTable();
                DataTable dtbalinv = new DataTable();
                string totalinvqty = "";
                string balanceamount = "";
                List<DcNumbers> getbalnaceitemslist = new List<DcNumbers>();
                DataTable Report = new DataTable();
                Report.Columns.Add("");
                Report.Columns.Add("");
                //inventary// cmd = new MySqlCommand("SELECT  productsdata.ProductName, closubtranprodcts.StockQty, productsdata.sno FROM clotrans INNER JOIN closubtranprodcts ON clotrans.Sno = closubtranprodcts.RefNo INNER JOIN productsdata ON closubtranprodcts.ProductID = productsdata.sno WHERE (clotrans.IndDate BETWEEN @d1 AND @d2) AND (clotrans.BranchId = @BranchID) GROUP BY productsdata.ProductName");
                if (Agentid != "ALL")
                {
                    cmd = new MySqlCommand("SELECT  inventory_monitor.Qty, invmaster.InvName, inventory_monitor.Inv_Sno, branchaccounts.Amount, branchdata.sno, branchdata.BranchName FROM inventory_monitor INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno INNER JOIN branchaccounts ON inventory_monitor.BranchId = branchaccounts.BranchId INNER JOIN branchdata ON branchaccounts.BranchId = branchdata.sno WHERE (inventory_monitor.BranchId = @branchid) AND (inventory_monitor.Qty > 0)");
                    cmd.Parameters.Add("@branchid", Agentid);
                    dtbalinv = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtbalinv.Rows)
                    {
                        DcNumbers getbalnaceitems = new DcNumbers();
                        getbalnaceitems.balanceamount = dr["Amount"].ToString();
                        getbalnaceitems.totalinvqty = dr["Qty"].ToString();
                        getbalnaceitems.ProductName = dr["InvName"].ToString();
                        getbalnaceitems.branch = dr["InvName"].ToString();
                        getbalnaceitems.branch = dr["BranchName"].ToString();
                        getbalnaceitemslist.Add(getbalnaceitems);
                    }
                    string response = GetJson(getbalnaceitemslist);
                    context.Response.Write(response);
                }
                else
                {
                    cmd = new MySqlCommand("SELECT inventory_monitor.Qty, invmaster.InvName, modifiedroutes.Sno, modifiedroutesubtable.BranchID, inventory_monitor.Inv_Sno, inventory_monitor.BranchId AS Expr1,branchdata.BranchName, branchdata.sno AS Expr2, branchaccounts.Amount FROM modifiedroutes INNER JOIN modifiedroutesubtable ON modifiedroutes.Sno = modifiedroutesubtable.RefNo INNER JOIN inventory_monitor ON modifiedroutesubtable.BranchID = inventory_monitor.BranchId INNER JOIN invmaster ON inventory_monitor.Inv_Sno = invmaster.sno INNER JOIN branchdata ON inventory_monitor.BranchId = branchdata.sno INNER JOIN branchaccounts ON branchdata.sno = branchaccounts.BranchId WHERE (modifiedroutes.Sno = @Branchid) AND (inventory_monitor.Qty > 0)");
                    cmd.Parameters.Add("@Branchid", Routeid);
                    dtbalinv = vdm.SelectQuery(cmd).Tables[0];
                    foreach (DataRow dr in dtbalinv.Rows)
                    {
                        DcNumbers getbalnaceitems = new DcNumbers();
                        getbalnaceitems.balanceamount = dr["Amount"].ToString();
                        getbalnaceitems.totalinvqty = dr["Qty"].ToString();
                        getbalnaceitems.ProductName = dr["InvName"].ToString();
                        getbalnaceitems.branch = dr["BranchName"].ToString();
                        getbalnaceitemslist.Add(getbalnaceitems);
                    }
                    string response = GetJson(getbalnaceitemslist);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }


        class AgentIncDecclass
        {
            public string BranchName { get; set; }
            public string SalesRepresentive { get; set; }
            public string Fromqty { get; set; }
            public string Toqty { get; set; }
            public string Due { get; set; }
            public string Crates { get; set; }
            public string IncreaseQty { get; set; }
            public string DecreaseQty { get; set; }
            public string Increasepercen { get; set; }
            public string Decreasepercen { get; set; }
            public string RouteName { get; set; }
            public string fromdate { get; set; }
            public string Branchid { get; set; }
            public string todate { get; set; }
            
        }







        DataTable Report = new DataTable();
        private void get_AgentIncDec(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string Branchid = context.Request["Branchid"];
                string frmdate = context.Request["fromdate"];
                DateTime fromdate = Convert.ToDateTime(frmdate);
                string tdate = context.Request["todate"];
                DateTime todate = Convert.ToDateTime(tdate);
                List<AgentIncDecclass> getAgentIncDecclasslst = new List<AgentIncDecclass>();
                Report = new DataTable();
                Report.Columns.Add("SNo");
                Report.Columns.Add("Sales Office Name");
                Report.Columns.Add("Route Name");
                Report.Columns.Add("FromDate");
                Report.Columns.Add("ToDate");
                Report.Columns.Add("Increase");
                Report.Columns.Add("Increase %");
                Report.Columns.Add("Decrease");
                Report.Columns.Add("Decrease %");

                string type = context.Request["type"];
                if (type == "Branchwise")
                {
                    DataTable dtbranch = new DataTable();
                    cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
                    cmd.Parameters.Add("@Branchid", Branchid);
                    DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
                    string branchtype = "";
                    if (dttable.Rows.Count > 0)
                    {
                        branchtype = dttable.Rows[0]["salestype"].ToString();
                    }
                    if (branchtype == "Plant")
                    {
                        //cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SuperBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
                        cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName, branchroutes.RouteName, branchroutes.Sno AS Routesno FROM branchmappingtable INNER JOIN  branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SuperBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
                        cmd.Parameters.Add("@BranchID", context.Session["branch"]);
                        dtbranch = vdm.SelectQuery(cmd).Tables[0];
                    }
                    else
                    {
                        cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName, branchroutes.RouteName, branchroutes.Sno AS Routesno FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SubBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
                        //cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName, branchroutes.RouteName, branchroutes.Sno AS Routesno FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SubBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
                        cmd.Parameters.Add("@BranchID", Branchid);
                        dtbranch = vdm.SelectQuery(cmd).Tables[0];
                    }
                    double fromqty = 0;
                    double toqty = 0;
                    double increseqty = 0;
                    double decreseeqty = 0;
                    double totfromqty = 0;
                    double tottoqty = 0;
                    double totincreseqty = 0;
                    double totdecreseeqty = 0;
                    if (dtbranch.Rows.Count > 0)
                    {
                        int i = 1;
                        int Totalcount = 1;
                        string BranchName = "";
                        foreach (DataRow drbranch in dtbranch.Rows)
                        {
                            DataRow newrow = Report.NewRow();
                            if (BranchName != drbranch["BranchName"].ToString())
                            {
                                if (Totalcount == 2)
                                {
                                    newrow["ToDate"] = todate;
                                }
                                if (Totalcount == 1)
                                {
                                    newrow["Sno"] = i++.ToString();
                                    newrow["Sales Office Name"] = drbranch["BranchName"].ToString();
                                    newrow["FromDate"] = fromdate;
                                }
                                else
                                {
                                    DataRow space1 = Report.NewRow();
                                    space1["Route Name"] = "Total";
                                    space1["FromDate"] = fromqty;
                                    space1["ToDate"] = toqty;
                                    space1["Increase"] = increseqty;
                                    space1["Decrease"] = decreseeqty;
                                    Report.Rows.Add(space1);
                                    newrow["Sno"] = i++.ToString();
                                    newrow["Sales Office Name"] = drbranch["BranchName"].ToString();
                                    Totalcount++;
                                    DataRow space = Report.NewRow();
                                    space["Route Name"] = "";
                                    Report.Rows.Add(space);
                                    totfromqty += fromqty;
                                    tottoqty += toqty;
                                    totincreseqty += increseqty;
                                    totdecreseeqty += decreseeqty;
                                    fromqty = 0;
                                    toqty = 0;
                                    increseqty = 0;
                                    decreseeqty = 0;
                                }
                            }
                            else
                            {
                                newrow["Sales Office Name"] = "";
                            }
                            Totalcount++;
                            BranchName = drbranch["BranchName"].ToString();
                            cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchroutes.Sno, branchroutes.RouteName ORDER BY RouteSno");
                            cmd.Parameters.Add("@branchID", drbranch["SubBranch"].ToString());
                            cmd.Parameters.Add("@d1", GetLowDate(fromdate));
                            cmd.Parameters.Add("@d2", GetHighDate(fromdate));
                            DataTable dtindentprev = vdm.SelectQuery(cmd).Tables[0];
                            cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchroutes.Sno, branchroutes.RouteName ORDER BY RouteSno");
                            cmd.Parameters.Add("@branchID", drbranch["SubBranch"].ToString());
                            cmd.Parameters.Add("@d1", GetLowDate(todate));
                            cmd.Parameters.Add("@d2", GetHighDate(todate));
                            DataTable dtindentpresent = vdm.SelectQuery(cmd).Tables[0];
                            double PrevIndent = 0;
                            double PresentIndent = 0;
                            double DifferenceIndent = 0;
                            if (dtindentprev.Rows.Count > 0)
                            {
                                foreach (DataRow drprev in dtindentprev.Select("RouteSno='" + drbranch["Routesno"].ToString() + "'"))
                                {
                                    double.TryParse(drprev["indentqty"].ToString(), out PrevIndent);
                                    fromqty += PrevIndent;
                                }
                                foreach (DataRow drpresnt in dtindentpresent.Select("RouteSno='" + drbranch["Routesno"].ToString() + "'"))
                                {
                                    double.TryParse(drpresnt["indentqty"].ToString(), out PresentIndent);
                                    toqty += PresentIndent;
                                }

                                DifferenceIndent = PrevIndent - PresentIndent;
                                newrow["Route Name"] = drbranch["RouteName"].ToString();
                                newrow["FromDate"] = PrevIndent;
                                newrow["ToDate"] = PresentIndent;
                                if (DifferenceIndent < 0)
                                {
                                    DifferenceIndent = Math.Abs(DifferenceIndent);
                                    DifferenceIndent = Math.Round(DifferenceIndent, 2);
                                    newrow["Increase"] = DifferenceIndent;
                                    increseqty += DifferenceIndent;
                                    double per = 0;
                                    if (DifferenceIndent != 0 && PrevIndent != 0)
                                    {
                                        per = (DifferenceIndent / PrevIndent) * 100;
                                    }
                                    per = Math.Round(per, 2);
                                    newrow["Increase %"] = per;

                                }
                                else
                                {
                                    DifferenceIndent = Math.Abs(DifferenceIndent);
                                    DifferenceIndent = Math.Round(DifferenceIndent, 2);
                                    newrow["Decrease"] = DifferenceIndent;
                                    decreseeqty += DifferenceIndent;
                                    double per = 0;
                                    if (DifferenceIndent != 0 && PrevIndent != 0)
                                    {
                                        per = (DifferenceIndent / PrevIndent) * 100;
                                    }
                                    per = Math.Round(per, 2);
                                    newrow["Decrease %"] = per;
                                }
                            }
                            //newrow["Route Name"] = drbranch["RouteName"].ToString();
                            Report.Rows.Add(newrow);
                        }
                    }
                    foreach (DataRow dr in Report.Rows)
                    {
                        AgentIncDecclass obj1 = new AgentIncDecclass();
                        obj1.BranchName = dr["Sales Office Name"].ToString();
                        obj1.RouteName = dr["Route Name"].ToString();
                        obj1.Fromqty = dr["FromDate"].ToString();
                        obj1.Toqty = dr["ToDate"].ToString();
                        obj1.fromdate = fromdate.ToString("dd/MM/yyyy");
                        obj1.todate = todate.ToString("dd/MM/yyyy");
                        //obj1.Due = dr["Amount"].ToString();
                        obj1.IncreaseQty = dr["Increase"].ToString();
                        obj1.DecreaseQty = dr["Decrease"].ToString();
                        obj1.Increasepercen = dr["Increase %"].ToString();
                        obj1.Decreasepercen = dr["Decrease %"].ToString();
                        getAgentIncDecclasslst.Add(obj1);
                    }
                    string response1 = GetJson(getAgentIncDecclasslst);
                    context.Response.Write(response1);
                }
                else
                {

                    Report = new DataTable();
                    Report.Columns.Add("SNo");
                    Report.Columns.Add("RouteName");
                    Report.Columns.Add("Agent Name");
                    Report.Columns.Add("SR Name");
                    Report.Columns.Add("FromDate");
                    Report.Columns.Add("Todate");
                    Report.Columns.Add("Due");
                    Report.Columns.Add("Crates");
                    Report.Columns.Add("Increase");
                    Report.Columns.Add("Increase %");
                    Report.Columns.Add("Increase Remarks");
                    Report.Columns.Add("Decrease");
                    Report.Columns.Add("Decrease %");
                    Report.Columns.Add("Decrease Remarks");
                    double fromqty = 0;
                    double toqty = 0;
                    double increseqty = 0;
                    double decreseeqty = 0;
                    cmd = new MySqlCommand("SELECT branchaccounts.BranchId, branchaccounts.Amount, branchaccounts.FineAmount, branchaccounts.Dtripid, branchaccounts.Ctripid, branchaccounts.SaleValue,branchmappingtable.SuperBranch FROM branchaccounts INNER JOIN branchmappingtable ON branchaccounts.BranchId = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @BranchID)");
                    cmd.Parameters.Add("@BranchID", Branchid);
                    DataTable dtagentbalance = vdm.SelectQuery(cmd).Tables[0];
                    cmd = new MySqlCommand("SELECT branchmappingtable.SuperBranch, inventory_monitor.Qty, inventory_monitor.Inv_Sno, inventory_monitor.BranchId FROM inventory_monitor INNER JOIN branchmappingtable ON inventory_monitor.BranchId = branchmappingtable.SubBranch WHERE (branchmappingtable.SuperBranch = @BranchID)");
                    cmd.Parameters.Add("@BranchID", Branchid);
                    DataTable dtinvebalance = vdm.SelectQuery(cmd).Tables[0];
                    cmd = new MySqlCommand("SELECT sno,salestype FROM salestypemanagement WHERE (status = 1) ORDER BY rank");
                    DataTable dtsalesType = vdm.SelectQuery(cmd).Tables[0];
                    double totfromqty = 0;
                    double tottoqty = 0;
                    double totamount = 0;
                    double totcrates = 0;
                    double grandtotamount = 0;
                    double grandtotcrates = 0;
                    double totincreseqty = 0;
                    double totdecreseeqty = 0;
                    double grandtotfromqty = 0;
                    double grandtottoqty = 0;
                    if (dtsalesType.Rows.Count > 0)
                    {
                        int i = 1;
                        int Totalcount = 1;
                        string Routename = "";
                        foreach (DataRow dr in dtsalesType.Rows)
                        {
                            string salestype = dr["salestype"].ToString();
                            if (salestype != "DISCONTINUED AGENTS")
                            {
                                cmd = new MySqlCommand("SELECT branchroutes.RouteName,branchdata.SalesType,branchdata.SalesRepresentative, branchroutes.Sno AS Routesno,branchdata.sno as bsno, branchdata.BranchName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno WHERE (branchdata.flag = 1) AND (branchroutes.BranchID = @BranchID) ORDER BY Routesno");
                                cmd.Parameters.Add("@BranchID", Branchid);
                                DataTable dtbranch = vdm.SelectQuery(cmd).Tables[0];
                                DataView viewLeaks = new DataView(dtbranch);
                                DataTable distinctroutes = viewLeaks.ToTable(true, "salestype", "RouteName");
                                DataTable distinctagents = viewLeaks.ToTable(true, "RouteName", "bsno");

                                foreach (DataRow dragents in distinctroutes.Select("salestype='" + dr["sno"].ToString() + "'"))
                                {
                                    foreach (DataRow drbranch in dtbranch.Select("salestype='" + dr["sno"].ToString() + "' and RouteName='" + dragents["RouteName"].ToString() + "'"))
                                    {
                                        DataRow newrow = Report.NewRow();
                                        if (Totalcount == 2)
                                        {
                                            newrow["ToDate"] = todate;
                                        }
                                        if (Totalcount == 1)
                                        {
                                            newrow["FromDate"] = fromdate;

                                        }
                                        newrow["Sno"] = i++.ToString();
                                        Totalcount++;
                                        Routename = drbranch["RouteName"].ToString();
                                        cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName,  branchdata.BranchName, branchdata.sno FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno LEFT OUTER JOIN  indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE  (branchdata.flag = 1) AND (branchroutes.Sno = @RouteID) GROUP BY branchdata.BranchName, branchdata.sno ORDER BY branchdata.sno");
                                        cmd.Parameters.Add("@RouteID", drbranch["Routesno"].ToString());
                                        cmd.Parameters.Add("@d1", GetLowDate(fromdate));
                                        cmd.Parameters.Add("@d2", GetHighDate(fromdate));
                                        DataTable dtindentprev = vdm.SelectQuery(cmd).Tables[0];
                                        cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName,  branchdata.BranchName, branchdata.sno FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutesubtable.BranchID = branchdata.sno LEFT OUTER JOIN  indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE  (branchdata.flag = 1) AND (branchroutes.Sno = @RouteID) GROUP BY branchdata.BranchName, branchdata.sno ORDER BY branchdata.sno");
                                        cmd.Parameters.Add("@RouteID", drbranch["Routesno"].ToString());
                                        cmd.Parameters.Add("@d1", GetLowDate(todate));
                                        cmd.Parameters.Add("@d2", GetHighDate(todate));
                                        DataTable dtindentpresent = vdm.SelectQuery(cmd).Tables[0];

                                        double PrevIndent = 0;
                                        double PresentIndent = 0;
                                        double DifferenceIndent = 0;
                                        double DifInd = 0;
                                        if (dtindentprev.Rows.Count > 0)
                                        {
                                            foreach (DataRow drprev in dtindentprev.Select("BranchID='" + drbranch["bsno"].ToString() + "'"))
                                            {
                                                double.TryParse(drprev["indentqty"].ToString(), out PrevIndent);

                                                totfromqty += PrevIndent;

                                            }
                                            foreach (DataRow drpresnt in dtindentpresent.Select("BranchID='" + drbranch["bsno"].ToString() + "'"))
                                            {
                                                double.TryParse(drpresnt["indentqty"].ToString(), out PresentIndent);
                                                tottoqty += PresentIndent;

                                            }

                                            DifferenceIndent = PresentIndent - PrevIndent;
                                            DifInd = PresentIndent - PrevIndent;
                                            newrow["RouteName"] = drbranch["RouteName"].ToString();

                                            newrow["Agent Name"] = drbranch["BranchName"].ToString();
                                            newrow["SR Name"] = drbranch["SalesRepresentative"].ToString();
                                            if (DifferenceIndent >= 0)
                                            {
                                                DifferenceIndent = Math.Abs(DifferenceIndent);
                                                DifferenceIndent = Math.Round(DifferenceIndent, 2);
                                                newrow["Increase"] = DifferenceIndent;
                                                increseqty += DifferenceIndent;
                                                totincreseqty += DifferenceIndent;
                                                double per = 0;
                                                if (DifferenceIndent != 0 && PrevIndent != 0)
                                                {
                                                    per = (DifferenceIndent / PrevIndent) * 100;
                                                }
                                                per = Math.Round(per, 2);
                                                newrow["Increase %"] = per;
                                                newrow["FromDate"] = PrevIndent;
                                                newrow["ToDate"] = PresentIndent;
                                            }
                                            else
                                            {
                                                if (PrevIndent == PresentIndent)
                                                {
                                                }
                                                else
                                                {
                                                    DifferenceIndent = Math.Abs(DifferenceIndent);
                                                    DifferenceIndent = Math.Round(DifferenceIndent, 2);
                                                    newrow["Decrease"] = DifferenceIndent;
                                                    decreseeqty += DifferenceIndent;
                                                    totdecreseeqty += DifferenceIndent;
                                                    double per = 0;
                                                    if (DifferenceIndent != 0 && PrevIndent != 0)
                                                    {
                                                        per = (DifferenceIndent / PrevIndent) * 100;
                                                    }
                                                    per = Math.Round(per, 2);
                                                    newrow["Decrease %"] = per;
                                                    newrow["FromDate"] = PrevIndent;
                                                    newrow["ToDate"] = PresentIndent;
                                                }
                                            }

                                        }
                                        Report.Rows.Add(newrow);
                                    }
                                }
                            }
                        }
                    }
                    foreach (DataRow dr in Report.Rows)
                    {

                        AgentIncDecclass obj1 = new AgentIncDecclass();
                        obj1.BranchName = dr["RouteName"].ToString();
                        obj1.RouteName = dr["Agent Name"].ToString();
                        obj1.Fromqty = dr["FromDate"].ToString();
                        obj1.fromdate = fromdate.ToString("dd/MM/yyyy");
                        obj1.todate = todate.ToString("dd/MM/yyyy");
                        obj1.Toqty = dr["ToDate"].ToString();
                        //obj1.Due = dr["Amount"].ToString();
                        obj1.IncreaseQty = dr["Increase"].ToString();
                        obj1.DecreaseQty = dr["Decrease"].ToString();
                        obj1.Increasepercen = dr["Increase %"].ToString();
                        obj1.Decreasepercen = dr["Decrease %"].ToString();
                        getAgentIncDecclasslst.Add(obj1);
                    }
                    string response = GetJson(getAgentIncDecclasslst);
                    context.Response.Write(response);
                }
            }
            catch
            {

            }
        }
        //private void get_BranchWiseIndentIncDec(HttpContext context)
        //{
        //    try
        //    {
        //        vdm = new VehicleDBMgr();
        //        string branchid = context.Request["branchid"];
        //        string FromDate = context.Request["fromdate"];
        //        DateTime From_Date = Convert.ToDateTime(FromDate);
        //        string Todate = context.Request["todate"];
        //        DateTime Enddate = Convert.ToDateTime(Todate);
        //        DateTime firstmonth = new DateTime();
        //        DateTime lastmonth = new DateTime();
        //        DataTable Report = new DataTable();
        //        Report.Columns.Add("SNo");
        //        Report.Columns.Add("Sales Office Name");
        //        Report.Columns.Add("Branchid");
        //        Report.Columns.Add("Route Name");
        //        Report.Columns.Add("FromDate");
        //        Report.Columns.Add("ToDate");
        //        Report.Columns.Add("Increase");
        //        Report.Columns.Add("Increase %");
        //        Report.Columns.Add("Decrease");
        //        Report.Columns.Add("Decrease %");
        //        List<AgentIncDecclass> getAgentIncDecclasslst = new List<AgentIncDecclass>();
        //        DataTable dtsalevalue = new DataTable();
        //        DataTable dtlekages = new DataTable();
        //        cmd = new MySqlCommand("SELECT branchdata.sno, salestypemanagement.salestype FROM branchdata INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (branchdata.sno = @Branchid)");
        //        cmd.Parameters.Add("@Branchid", branchid);
        //        DataTable dttable = vdm.SelectQuery(cmd).Tables[0];
        //        string branchtype = "";
        //        if (dttable.Rows.Count > 0)
        //        {
        //            branchtype = dttable.Rows[0]["salestype"].ToString();
        //        }
        //        if (branchid == "1")
        //        {
        //        }
        //        else if (branchtype == "Plant")
        //        {
        //        }
        //        else if (branchtype == "SALES OFFICE")
        //        {
        //            cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName, branchroutes.RouteName, branchroutes.Sno AS Routesno FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SubBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
        //            //cmd = new MySqlCommand("SELECT  branchmappingtable.SubBranch, branchmappingtable.SuperBranch, branchdata.BranchName, branchroutes.RouteName, branchroutes.Sno AS Routesno FROM branchmappingtable INNER JOIN branchdata ON branchmappingtable.SubBranch = branchdata.sno INNER JOIN branchroutes ON branchdata.sno = branchroutes.BranchID WHERE (branchroutes.flag = 1) AND (branchmappingtable.SubBranch = @BranchID) GROUP BY branchroutes.Sno ORDER BY branchdata.sno");
        //            cmd.Parameters.Add("@BranchID", branchid);
        //            DataTable dtbranch = vdm.SelectQuery(cmd).Tables[0];
        //            double fromqty = 0;
        //            double toqty = 0;
        //            double increseqty = 0;
        //            double decreseeqty = 0;
        //            double totfromqty = 0;
        //            double tottoqty = 0;
        //            double totincreseqty = 0;
        //            double totdecreseeqty = 0;
        //            if (dtbranch.Rows.Count > 0)
        //            {
        //                int i = 1;
        //                int Totalcount = 1;
        //                string BranchName = "";
        //                foreach (DataRow drbranch in dtbranch.Rows)
        //                {
        //                    DataRow newrow = Report.NewRow();
        //                    if (BranchName != drbranch["BranchName"].ToString())
        //                    {
        //                        if (Totalcount == 2)
        //                        {
        //                            newrow["ToDate"] = From_Date;
        //                        }
        //                        if (Totalcount == 1)
        //                        {
        //                            newrow["Sno"] = i++.ToString();
        //                            newrow["Sales Office Name"] = drbranch["RouteName"].ToString();
        //                            newrow["Branchid"] = drbranch["SubBranch"].ToString();
        //                            newrow["FromDate"] = Enddate;
        //                        }
        //                        else
        //                        {
        //                            //DataRow space1 = Report.NewRow();
        //                            //space1["Route Name"] = "Total";
        //                            //space1["FromDate"] = fromqty;
        //                            //space1["ToDate"] = toqty;
        //                            //space1["Increase"] = increseqty;
        //                            //space1["Decrease"] = decreseeqty;
        //                            //Report.Rows.Add(space1);
        //                            newrow["Sno"] = i++.ToString();
        //                            newrow["Sales Office Name"] = drbranch["RouteName"].ToString();
        //                            newrow["Branchid"] = drbranch["SubBranch"].ToString();
        //                            Totalcount++;
        //                            //DataRow space = Report.NewRow();
        //                            //space["Route Name"] = "";
        //                            //Report.Rows.Add(space);
        //                            totfromqty += fromqty;
        //                            tottoqty += toqty;
        //                            totincreseqty += increseqty;
        //                            totdecreseeqty += decreseeqty;
        //                            fromqty = 0;
        //                            toqty = 0;
        //                            increseqty = 0;
        //                            decreseeqty = 0;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        newrow["Sales Office Name"] = "";
        //                    }
        //                    Totalcount++;
        //                    BranchName = drbranch["BranchName"].ToString();
        //                    //cmd = new MySqlCommand("SELECT  branchroutesubtable.BranchID,branchdata.sno, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName, branchdata.BranchName FROM  branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutes.BranchID = branchdata.sno LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT  IndentNo, Branch_id, I_date FROM  indents WHERE  (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchdata.BranchName");
        //                    cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchroutes.Sno, branchroutes.RouteName ORDER BY RouteSno");
        //                    cmd.Parameters.Add("@branchID", drbranch["SubBranch"].ToString());
        //                    cmd.Parameters.Add("@d1", GetLowDate(From_Date));
        //                    cmd.Parameters.Add("@d2", GetHighDate(Enddate));
        //                    DataTable dtindentprev = vdm.SelectQuery(cmd).Tables[0];
        //                    //cmd = new MySqlCommand("SELECT  branchroutesubtable.BranchID,branchdata.sno,ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName, branchdata.BranchName FROM  branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo INNER JOIN branchdata ON branchroutes.BranchID = branchdata.sno LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT  IndentNo, Branch_id, I_date FROM  indents WHERE  (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchdata.BranchName");
        //                    cmd = new MySqlCommand("SELECT branchroutesubtable.BranchID, ROUND(SUM(indents_subtable.unitQty), 2) AS indentqty, branchroutes.Sno AS RouteSno, branchroutes.RouteName FROM branchroutes INNER JOIN branchroutesubtable ON branchroutes.Sno = branchroutesubtable.RefNo LEFT OUTER JOIN indents_subtable INNER JOIN (SELECT IndentNo, Branch_id, I_date FROM indents WHERE (I_date BETWEEN @d1 AND @d2)) indnts ON indents_subtable.IndentNo = indnts.IndentNo ON  branchroutesubtable.BranchID = indnts.Branch_id WHERE (branchroutes.BranchID = @BranchID) AND (branchroutes.flag = 1) GROUP BY branchroutes.Sno, branchroutes.RouteName ORDER BY RouteSno");
        //                    cmd.Parameters.Add("@branchID", drbranch["SubBranch"].ToString());
        //                    cmd.Parameters.Add("@d1", GetLowDate(From_Date));
        //                    cmd.Parameters.Add("@d2", GetHighDate(Enddate));
        //                    DataTable dtindentpresent = vdm.SelectQuery(cmd).Tables[0];
        //                    double PrevIndent = 0;
        //                    double PresentIndent = 0;
        //                    double DifferenceIndent = 0;
        //                    if (dtindentprev.Rows.Count > 0)
        //                    {
        //                        foreach (DataRow drprev in dtindentprev.Select("RouteSno='" + drbranch["Routesno"].ToString() + "'"))
        //                        {
        //                            double.TryParse(drprev["indentqty"].ToString(), out PrevIndent);
        //                            fromqty += PrevIndent;
        //                        }
        //                        foreach (DataRow drpresnt in dtindentpresent.Select("RouteSno='" + drbranch["Routesno"].ToString() + "'"))
        //                        {
        //                            double.TryParse(drpresnt["indentqty"].ToString(), out PresentIndent);
        //                            toqty += PresentIndent;
        //                        }
        //                        DifferenceIndent = PrevIndent - PresentIndent;
        //                        newrow["Route Name"] = drbranch["RouteName"].ToString();
        //                        newrow["FromDate"] = PrevIndent;
        //                        newrow["ToDate"] = PresentIndent;
        //                        if (DifferenceIndent < 0)
        //                        {
        //                            DifferenceIndent = Math.Abs(DifferenceIndent);
        //                            DifferenceIndent = Math.Round(DifferenceIndent, 2);
        //                            newrow["Increase"] = DifferenceIndent;
        //                            increseqty += DifferenceIndent;
        //                            double per = 0;
        //                            if (DifferenceIndent != 0 && PrevIndent != 0)
        //                            {
        //                                per = (DifferenceIndent / PrevIndent) * 100;
        //                            }
        //                            per = Math.Round(per, 2);
        //                            newrow["Increase %"] = per;

        //                        }
        //                        else
        //                        {
        //                            DifferenceIndent = Math.Abs(DifferenceIndent);
        //                            DifferenceIndent = Math.Round(DifferenceIndent, 2);
        //                            newrow["Decrease"] = DifferenceIndent;
        //                            decreseeqty += DifferenceIndent;
        //                            double per = 0;
        //                            if (DifferenceIndent != 0 && PrevIndent != 0)
        //                            {
        //                                per = (DifferenceIndent / PrevIndent) * 100;
        //                            }
        //                            per = Math.Round(per, 2);
        //                            newrow["Decrease %"] = per;
        //                        }
        //                    }
        //                    //newrow["Route Name"] = drbranch["RouteName"].ToString();
        //                    Report.Rows.Add(newrow);
        //                }
        //            }
        //        }
        //        else
        //        {

        //        }
        //        List<SalelDetails> branchwiseproductlist = new List<SalelDetails>();
        //        foreach (DataRow dr in Report.Rows)
        //        {
        //            AgentIncDecclass obj1 = new AgentIncDecclass();
        //            obj1.BranchName = dr["Sales Office Name"].ToString();
        //            obj1.RouteName = dr["Route Name"].ToString();
        //            obj1.Fromqty = dr["FromDate"].ToString();
        //            obj1.Toqty = dr["ToDate"].ToString();
        //            obj1.fromdate = From_Date.ToString("dd/MM/yyyy");
        //            obj1.todate = Enddate.ToString("dd/MM/yyyy");
        //            obj1.Branchid = dr["Branchid"].ToString();
        //            obj1.IncreaseQty = dr["Increase"].ToString();
        //            obj1.DecreaseQty = dr["Decrease"].ToString();
        //            obj1.Increasepercen = dr["Increase %"].ToString();
        //            obj1.Decreasepercen = dr["Decrease %"].ToString();
        //            getAgentIncDecclasslst.Add(obj1);
        //        }
        //        string response1 = GetJson(getAgentIncDecclasslst);
        //        context.Response.Write(response1);
        //    }
        //    catch (Exception ex)
        //    {
        //        string Response = GetJson(ex.Message);
        //        context.Response.Write(Response);
        //    }
        //}
        private DateTime GetLowMonthRetrive(DateTime dt)
        {
            double Day, Hour, Min, Sec;
            DateTime DT = dt;
            DT = dt;
            Day = -dt.Day + 1;
            Hour = -dt.Hour;
            Min = -dt.Minute;
            Sec = -dt.Second;
            DT = DT.AddDays(Day);
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            return DT;

        }
        private DateTime GetHighMonth(DateTime dt)
        {
            double Day, Hour, Min, Sec;
            DateTime DT = DateTime.Now;
            Day = 31 - dt.Day;
            Hour = 23 - dt.Hour;
            Min = 59 - dt.Minute;
            Sec = 59 - dt.Second;
            DT = dt;
            DT = DT.AddDays(Day);
            DT = DT.AddHours(Hour);
            DT = DT.AddMinutes(Min);
            DT = DT.AddSeconds(Sec);
            if (DT.Day == 3)
            {
                DT = DT.AddDays(-3);
            }
            else if (DT.Day == 2)
            {
                DT = DT.AddDays(-2);
            }
            else if (DT.Day == 1)
            {
                DT = DT.AddDays(-1);
            }
            return DT;
        }
        private void updatesalestypemanage(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                string username = context.Request["username"];
                cmd = new MySqlCommand("select salestype,flag,sno,status From salestypemanagement Where UserData_sno= @username order by rank");
                cmd.Parameters.Add("@username", context.Session["userdata_sno"].ToString());
                DataTable dt = vdm.SelectQuery(cmd).Tables[0];
                List<Salestype> Saleslist = new List<Salestype>();
                foreach (DataRow dr in dt.Rows)
                {
                    Salestype GetSalestype = new Salestype();
                    GetSalestype.salestype = dr["salestype"].ToString();
                    GetSalestype.flag = dr["flag"].ToString();
                    GetSalestype.status = dr["status"].ToString();
                    GetSalestype.sno = dr["sno"].ToString();
                    Saleslist.Add(GetSalestype);
                }
                string response = GetJson(Saleslist);
                context.Response.Write(response);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                string response = GetJson(msg);
                context.Response.Write(response);
            }
        }
        public class Salestype
        {
            public string sno { get; set; }
            public string salestype { get; set; }
            public string flag { get; set; }
            public string status { get; set; }
        }
        private void GetLineChartValues(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();

                string Fmdate = context.Request["startDate"];
                string AgentName = context.Request["AgentName"];
                string RouteName = context.Request["RouteName"];
                string SalesOffice = context.Request["SalesOffice"];
                string Type = context.Request["Type"];
                string ddldatatype = context.Request["ddldatatype"];
                DateTime fmdate = Convert.ToDateTime(Fmdate);
                string CTime = fmdate.ToString();
                DateTime dtFrmDate = Convert.ToDateTime(CTime);
                DateTime FromDate = DateTime.Now;
                string toDate = context.Request["endDate"];
                DateTime tDate = Convert.ToDateTime(toDate);
                string CTTime = tDate.ToString();
                DateTime dttoDate = Convert.ToDateTime(CTTime);
                DateTime Enddate = DateTime.Now;
                string time = dtFrmDate.ToString("dd-MM-yyyy HH:mm");//
                string[] fromdatestrig = time.Split(' ');
                if (fromdatestrig.Length > 1)
                {
                    if (fromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = fromdatestrig[0].Split('-');
                        string[] times = fromdatestrig[1].Split(':');
                        FromDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                string endtime = dttoDate.ToString("dd-MM-yyyy HH:mm");
                string[] endfromdatestrig = endtime.Split(' ');
                if (endfromdatestrig.Length > 1)
                {
                    if (endfromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = endfromdatestrig[0].Split('-');
                        string[] times = endfromdatestrig[1].Split(':');
                        Enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                List<LineChartValuesclass> LineChartValuelist = new List<LineChartValuesclass>();
                DataTable dtReport = new DataTable();
                if (ddldatatype == "Day Wise")
                {
                    TimeSpan dateSpan = Enddate.Subtract(FromDate);
                    int NoOfdays = dateSpan.Days;
                    if (NoOfdays > 32)
                    {
                        string msg = "Please Select Monthly Wise";
                        List<string> LineChartlist = new List<string>();
                        LineChartlist.Add(msg);
                        string err_response = GetJson(LineChartlist);
                        context.Response.Write(err_response);
                    }
                    else
                    {
                        if (Type == "Sales Office Wise")
                        {
                            cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID) GROUP BY  DATE(indents.I_date)");
                            cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                            cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                            cmd.Parameters.Add("@BranchID", SalesOffice);
                            dtReport = vdm.SelectQuery(cmd).Tables[0];
                        }
                        if (Type == "Route Wise")
                        {
                            cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutesubtable.RefNo FROM indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID  WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchroutesubtable.RefNo = @RouteID) AND (indents_subtable.DeliveryQty > 0)  GROUP BY indents_subtable.DTripId");
                            cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                            cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                            cmd.Parameters.Add("@RouteID", RouteName);
                            dtReport = vdm.SelectQuery(cmd).Tables[0];
                        }
                        if (Type == "Agent Wise")
                        {
                            cmd = new MySqlCommand("SELECT round(SUM(indents_subtable.unitQty),2) AS unitQty, round(SUM(indents_subtable.DeliveryQty),2) AS DeliveryQty,indents.I_date FROM  indents INNER JOIN indents_subtable ON indents.IndentNo = indents_subtable.IndentNo INNER JOIN productsdata ON indents_subtable.Product_sno = productsdata.sno WHERE (indents.Branch_id = @BranchID) AND (indents.I_date BETWEEN @d1 AND @d2)GROUP BY indents.I_date");
                            cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                            cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                            cmd.Parameters.Add("@BranchID", AgentName);
                            dtReport = vdm.SelectQuery(cmd).Tables[0];
                        }
                        LineChartValuesclass getLineChart = new LineChartValuesclass();
                        List<string> unitlist = new List<string>();
                        List<string> Deliverlist = new List<string>();
                        List<string> Averagelist = new List<string>();
                        List<string> Datelist = new List<string>();
                        List<string> Statuslist = new List<string>();
                        List<string> ActMillist = new List<string>();
                        if (dtReport.Rows.Count > 0)
                        {

                            string MainQty = "";
                            string DelQty = "";
                            string IndDate = "";
                            string AvgMileage = "";
                            double avgSaleQty = 0;
                            int count = 0;
                            string status = "";
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string unitQty = dr["unitQty"].ToString();
                                MainQty += unitQty + ",";
                                string DeliveryQty = dr["DeliveryQty"].ToString();
                                DelQty += DeliveryQty + ",";
                                double milltr = 0;
                                double.TryParse(dr["DeliveryQty"].ToString(), out milltr);
                                avgSaleQty += milltr;
                                string IndentDate = dr["I_date"].ToString();
                                DateTime now = Convert.ToDateTime(IndentDate).AddDays(1);
                                string dayname = now.DayOfWeek.ToString();
                                DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                                string ChangedTime = dtIndentDate.ToString("dd");
                                string newdate = ChangedTime + "/" + dayname;
                                IndDate += newdate + ",";
                                //sttus +=
                                count++;
                            }
                            double avg = 0;
                            avg = (avgSaleQty / count);
                            avg = Math.Round(avg, 2);
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string TodayMileage = dr["DeliveryQty"].ToString();
                                if (TodayMileage != "0")
                                {
                                    AvgMileage += avg.ToString() + ",";
                                }
                            }
                            AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                            IndDate = IndDate.Substring(0, IndDate.Length - 1);
                            DelQty = DelQty.Substring(0, DelQty.Length - 1);
                            MainQty = MainQty.Substring(0, MainQty.Length - 1);
                            //Deliverlist.Add(DelQty);
                            //Averagelist.Add(AvgMileage);
                            //Statuslist.Add("Sales");
                            //Statuslist.Add("Avg Sales");
                            getLineChart.IndentDate = IndDate;
                            getLineChart.aqty = AvgMileage;
                            getLineChart.dqty = DelQty;
                            //getLineChart.Sstatus = IndDate;
                            //getLineChart.DeliveryQty = Deliverlist;
                            //getLineChart.AvgQty = Averagelist;
                            getLineChart.Status = Statuslist;
                            getLineChart.ActMileage = ActMillist;
                            LineChartValuelist.Add(getLineChart);
                        }
                        //if (Type == "Sales Office Wise")
                        //{
                        //    //cmd = new MySqlCommand("select salestype,flag,sno,status,club_code From salestypemanagement WHERE (status = 1) group by club_code order by sno DESC");
                        //    //DataTable dtsales = vdm.SelectQuery(cmd).Tables[0];
                        //    //foreach (DataRow dr in dtsales.Rows)
                        //    //{
                        //    //if (dr["club_code"].ToString() == "4")
                        //    //{
                        //    //    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID)  GROUP BY  DATE(indents.I_date)");
                        //    //    //cmd.Parameters.Add("@SalesType", dr["sno"].ToString());
                        //    //}
                        //    //else
                        //    //{
                        //    cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID)   GROUP BY  DATE(indents.I_date)");
                        //    //cmd.Parameters.Add("@SalesType", dr["sno"].ToString());
                        //    //}
                        //    cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        //    cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        //    cmd.Parameters.Add("@BranchID", SalesOffice);
                        //    DataTable dtclass = vdm.SelectQuery(cmd).Tables[0];
                        //    //if (dtclass.Rows.Count > 0)
                        //    //{
                        //    //    if (dr["club_code"].ToString() == "4")
                        //    //    {
                        //    //        Statuslist.Add("INSTITUTIONAL");
                        //    //        Statuslist.Add("Avg Sales");
                        //    //    }
                        //    //    else
                        //    //    {
                        //    //        Statuslist.Add(dr["salestype"].ToString());
                        //    //        Statuslist.Add("Avg Sales");
                        //    //    }
                        //    getLineChart.Status = Statuslist;
                        //    string DelQty = "";
                        //    string IndDate = "";
                        //    string AvgMileage = "";
                        //    double avgSaleQty = 0;
                        //    int count = 0;
                        //    foreach (DataRow drc in dtclass.Rows)
                        //    {
                        //        string DeliveryQty = drc["DeliveryQty"].ToString();
                        //        DelQty += DeliveryQty + ",";
                        //        double milltr = 0;
                        //        double.TryParse(drc["DeliveryQty"].ToString(), out milltr);
                        //        avgSaleQty += milltr;
                        //        string IndentDate = drc["I_date"].ToString();
                        //        DateTime now = Convert.ToDateTime(IndentDate).AddDays(1);
                        //        string dayname = now.DayOfWeek.ToString();
                        //        DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                        //        string ChangedTime = dtIndentDate.ToString("dd");
                        //        string newdate = ChangedTime + "/" + dayname;
                        //        IndDate += newdate + ",";
                        //        count++;
                        //    }
                        //    double avg = 0;
                        //    avg = (avgSaleQty / count);
                        //    avg = Math.Round(avg, 2);
                        //    foreach (DataRow drc in dtclass.Rows)
                        //    {
                        //        string TodayMileage = drc["DeliveryQty"].ToString();
                        //        if (TodayMileage != "0")
                        //        {
                        //            AvgMileage += avg.ToString() + ",";
                        //        }
                        //    }
                        //    AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                        //    IndDate = IndDate.Substring(0, IndDate.Length - 1);
                        //    DelQty = DelQty.Substring(0, DelQty.Length - 1);
                        //    getLineChart.IndentDate = IndDate;
                        //    getLineChart.aqty = AvgMileage;
                        //    getLineChart.dqty = DelQty;
                        //    LineChartValuelist.Add(getLineChart);
                        //}
                        //}
                        //}
                        string errresponse = GetJson(LineChartValuelist);
                        context.Response.Write(errresponse);
                    }
                }
                else
                {
                    DataTable Report = new DataTable();
                    DateTime firstmonth = new DateTime();
                    DateTime lastmonth = new DateTime();
                    Enddate = Enddate.AddMonths(1);
                    TimeSpan dateSpan = Enddate.Subtract(FromDate);
                    int years = (dateSpan.Days / 365);
                    int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                    if (Type == "Sales Office Wise")
                    {
                        Report.Columns.Add("SNo");
                        Report.Columns.Add("Date");
                        Report.Columns.Add("Qty");
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(FromDate.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchroutes.BranchID = @BranchID) GROUP BY branchroutes.BranchID");
                                cmd.Parameters.Add("@BranchID", SalesOffice);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["SNo"] = i++.ToString();
                                    newrow["Date"] = ChangedTime1;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    double qty = 0;
                                    qty = delQty / NoOfdays;
                                    newrow["Qty"] = qty.ToString("F2");
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                    if (Type == "Route Wise")
                    {
                        Report.Columns.Add("SNo");
                        Report.Columns.Add("Date");
                        Report.Columns.Add("Qty");
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(FromDate.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchroutesubtable ON indents.Branch_id = branchroutesubtable.BranchID WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (branchroutesubtable.RefNo = @RouteID) GROUP BY branchroutesubtable.RefNo");
                                cmd.Parameters.Add("@RouteID", RouteName);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["SNo"] = i++.ToString();
                                    newrow["Date"] = ChangedTime1;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    newrow["Qty"] = delQty.ToString();
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                    if (Type == "Agent Wise")
                    {
                        Report.Columns.Add("SNo");
                        Report.Columns.Add("Date");
                        Report.Columns.Add("Qty");
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(FromDate.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents.Branch_id = @AgentID) GROUP BY indents.Branch_id");
                                cmd.Parameters.Add("@AgentID", AgentName);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["SNo"] = i++.ToString();
                                    newrow["Date"] = ChangedTime1;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    newrow["Qty"] = delQty.ToString();
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                    }
                    if (Report.Rows.Count > 0)
                    {
                        LineChartValuesclass getLineChart = new LineChartValuesclass();
                        List<string> unitlist = new List<string>();
                        List<string> Deliverlist = new List<string>();
                        List<string> Datelist = new List<string>();
                        List<string> Statuslist = new List<string>();
                        List<string> ActMillist = new List<string>();
                        string MainQty = "";
                        string DelQty = "";
                        string IndDate = "";
                        string AvgMileage = "";
                        double avgSaleQty = 0;
                        int count = 0;
                        foreach (DataRow dr in Report.Rows)
                        {
                            string DeliveryQty = dr["Qty"].ToString();
                            DelQty += DeliveryQty + ",";
                            double milltr = 0;
                            double.TryParse(dr["Qty"].ToString(), out milltr);
                            avgSaleQty += milltr;
                            string IndentDate = dr["Date"].ToString();
                            IndDate += IndentDate + ",";
                            count++;
                        }
                        double avg = 0;
                        avg = (avgSaleQty / count);
                        avg = Math.Round(avg, 2);
                        foreach (DataRow dr in Report.Rows)
                        {
                            string TodayMileage = dr["Qty"].ToString();
                            if (TodayMileage != "0")
                            {
                                AvgMileage += avg.ToString() + ",";
                            }
                        }
                        AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                        IndDate = IndDate.Substring(0, IndDate.Length - 1);
                        DelQty = DelQty.Substring(0, DelQty.Length - 1);
                        //Deliverlist.Add(DelQty);
                        //Deliverlist.Add(AvgMileage);
                        //Statuslist.Add("Saels");
                        //Statuslist.Add("Avg Sales");
                        getLineChart.IndentDate = IndDate;
                        getLineChart.IndentDate = IndDate;
                        getLineChart.aqty = AvgMileage;
                        getLineChart.dqty = DelQty;
                        //getLineChart.DeliveryQty = Deliverlist;
                        //getLineChart.UnitQty = MainQty;
                        //getLineChart.Status = Statuslist;
                        //getLineChart.ActMileage = ActMillist;
                        LineChartValuelist.Add(getLineChart);
                    }
                    string errresponse = GetJson(LineChartValuelist);
                    context.Response.Write(errresponse);
                }
            }
            catch
            {
            }
        }
        public class LineChartValuesclass
        {
            public List<string> DeliveryQty { get; set; }
            public List<string> AvgQty { get; set; }
            public List<string> Status { get; set; }
            public string IndentDate { get; set; }
            public string dqty { get; set; }
            public string aqty { get; set; }

            public string crtesclo { get; set; }
            public string cratesissue { get; set; }

            public string cansclo { get; set; }
            public string cansissue { get; set; }

            public string Sstatus { get; set; }
            public string UnitQty { get; set; }
            public List<string> ActMileage { get; set; }
        }
        private void GetPieChart_ClassificationType(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();
                DateTime FromDate = DateTime.Now;
                string StartDate = context.Request["startDate"];
                string ddlSalesOffice = context.Request["ddlSalesOffice"];
                DateTime fmdate = Convert.ToDateTime(StartDate);
                string enddate = context.Request["enddate"];
                DateTime fmenddate = Convert.ToDateTime(enddate);
                string time = fmdate.ToString("dd-MM-yyyy HH:mm");
                string[] fromdatestrig = time.Split(' ');
                if (fromdatestrig.Length > 1)
                {
                    if (fromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = fromdatestrig[0].Split('-');
                        string[] times = fromdatestrig[1].Split(':');
                        FromDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                string ddlType = context.Request["ddlType"];
                List<PieValues> lPieValueslist = new List<PieValues>();
                List<string> RouteList = new List<string>();
                List<string> AmountList = new List<string>();
                List<string> DeliveryList = new List<string>();
                List<string> AvgQtyList = new List<string>();
                TimeSpan dateSpan = fmenddate.Subtract(fmdate);
                int NoOfdays = dateSpan.Days;

                cmd = new MySqlCommand("SELECT  ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty,salestypemanagement.salestype , ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID, salestypemanagement.club_code FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno INNER JOIN salestypemanagement ON branchdata.SalesType = salestypemanagement.sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID)  GROUP BY salestypemanagement.club_code");
                cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(fmenddate.AddDays(-1)));
                cmd.Parameters.Add("@BranchID", ddlSalesOffice);
                DataTable dtpie = vdm.SelectQuery(cmd).Tables[0];
                double totalqty = 0;
                foreach (DataRow dr in dtpie.Rows)
                {
                    double DeliveryQty = 0;
                    double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                    totalqty += DeliveryQty;
                    totalqty = Math.Round(totalqty, 2);
                }
                foreach (DataRow dr in dtpie.Rows)
                {
                    if (dr["club_code"].ToString() == "4")
                    {
                        RouteList.Add("INSTITUTIONAL");
                    }
                    else
                    {
                        RouteList.Add(dr["salestype"].ToString());
                    }
                    double DeliveryQty = 0;
                    double.TryParse(dr["DeliveryQty"].ToString(), out DeliveryQty);
                    double avgqty = 0;
                    avgqty = DeliveryQty / NoOfdays;
                    double percent = 0;
                    percent = (DeliveryQty / totalqty) * 100;
                    percent = Math.Round(percent, 2);
                    avgqty = Math.Round(avgqty, 2);
                    string Amount = percent.ToString();
                    if (Amount == "")
                    {
                        Amount = "0";
                    }
                    AmountList.Add(Amount);
                    AvgQtyList.Add(avgqty.ToString());
                    DeliveryList.Add(dr["DeliveryQty"].ToString());
                }

                PieValues GetPieValues = new PieValues();
                GetPieValues.RouteName = RouteList;
                GetPieValues.Amount = AmountList;
                GetPieValues.totalqty = totalqty.ToString();
                GetPieValues.DeliveryQty = DeliveryList;
                GetPieValues.AverageyQty = AvgQtyList;
                lPieValueslist.Add(GetPieValues);
                //}
                string errresponse = GetJson(lPieValueslist);
                context.Response.Write(errresponse);
            }
            catch
            {
            }
        }
        public class PieValues
        {
            public List<string> RouteName { get; set; }
            public List<string> Amount { get; set; }
            public List<string> DeliveryQty { get; set; }
            public List<string> AverageyQty { get; set; }
            public List<string> catidandBranchid { get; set; }
            public string totalqty { get; set; }
            public List<PieValueTableClass> PieValueTableClass { get; set; }
        }

        public class PieValueTableClass
        {
            public string RouteName { get; set; }
            public string Routeid { get; set; }
            public string Amount { get; set; }
            public string DeliveryQty { get; set; }
            public string AverageyQty { get; set; }
            public string catidandBranchid { get; set; }
        }

        private void GetLineChart_agentinventorytransactions(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();

                string Fmdate = context.Request["startDate"];
                string AgentName = context.Request["AgentName"];
                string RouteName = context.Request["RouteName"];
                string SalesOffice = context.Request["SalesOffice"];
                string Type = context.Request["Type"];
                string ddldatatype = context.Request["ddldatatype"];
                ////string Fmdate = context.Request["txtFromdate"];
                DateTime fmdate = Convert.ToDateTime(Fmdate);
                string CTime = fmdate.ToString();
                DateTime dtFrmDate = Convert.ToDateTime(CTime);
                DateTime FromDate = DateTime.Now;
                string toDate = context.Request["endDate"];
                //string toDate = context.Request["txtTodate"];
                DateTime tDate = Convert.ToDateTime(toDate);
                string CTTime = tDate.ToString();
                DateTime dttoDate = Convert.ToDateTime(CTTime);
                DateTime Enddate = DateTime.Now;
                string time = dtFrmDate.ToString("dd-MM-yyyy HH:mm");//
                string[] fromdatestrig = time.Split(' ');
                if (fromdatestrig.Length > 1)
                {
                    if (fromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = fromdatestrig[0].Split('-');
                        string[] times = fromdatestrig[1].Split(':');
                        FromDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                string endtime = dttoDate.ToString("dd-MM-yyyy HH:mm");
                string[] endfromdatestrig = endtime.Split(' ');
                if (endfromdatestrig.Length > 1)
                {
                    if (endfromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = endfromdatestrig[0].Split('-');
                        string[] times = endfromdatestrig[1].Split(':');
                        Enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                List<LineChartValuesclass> LineChartValuelist = new List<LineChartValuesclass>();
                DataTable dtReport = new DataTable();
                if (ddldatatype == "Day Wise")
                {
                    if (Type == "Sales Office Wise")
                    {
                        cmd = new MySqlCommand("SELECT SUM(due_trans_inventory.isuued) AS isuued, SUM(due_trans_inventory.closing) AS closing, SUM(due_trans_inventory.issue10) AS issue10, SUM(due_trans_inventory.clo10) AS clo10, SUM(due_trans_inventory.issu20) AS issu20, SUM(due_trans_inventory.clo20) AS clo20, SUM(due_trans_inventory.issu40) AS issu40, SUM(due_trans_inventory.clo40) AS clo40, due_trans_inventory.doe FROM  due_trans_inventory INNER JOIN branchroutesubtable ON due_trans_inventory.agentid = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (due_trans_inventory.doe BETWEEN @d1 AND @d2) AND (branchroutes.BranchID = @BranchID) GROUP BY due_trans_inventory.doe, branchroutes.BranchID");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@BranchID", SalesOffice);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (Type == "Route Wise")
                    {
                        cmd = new MySqlCommand("SELECT SUM(due_trans_inventory.isuued) AS isuued, SUM(due_trans_inventory.closing) AS closing, SUM(due_trans_inventory.issue10) AS issue10, SUM(due_trans_inventory.clo10) AS clo10, SUM(due_trans_inventory.issu20) AS issu20, SUM(due_trans_inventory.clo20) AS clo20, SUM(due_trans_inventory.issu40) AS issu40, SUM(due_trans_inventory.clo40) AS clo40, due_trans_inventory.doe FROM due_trans_inventory INNER JOIN branchroutesubtable ON due_trans_inventory.agentid = branchroutesubtable.BranchID WHERE (due_trans_inventory.doe BETWEEN @d1 AND @d2) AND (branchroutesubtable.RefNo = @RouteID) GROUP BY branchroutesubtable.RefNo, due_trans_inventory.doe");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@RouteID", RouteName);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (Type == "Agent Wise")
                    {
                        cmd = new MySqlCommand("SELECT sno, inv_sno, oppening, isuued, received, closing, due_trans_sno, branchid, agentid, doe, opp10, issue10, rec10, clo10, opp20, issu20, rec20, clo20, opp40, issu40, rec40, clo40 FROM due_trans_inventory WHERE (doe BETWEEN @d1 AND @d2) AND (agentid = @agentid) ORDER BY doe");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@agentid", AgentName);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (dtReport.Rows.Count > 0)
                    {
                        LineChartValuesclass getLineChart = new LineChartValuesclass();
                        List<string> unitlist = new List<string>();
                        List<string> Deliverlist = new List<string>();
                        List<string> Datelist = new List<string>();
                        List<string> Statuslist = new List<string>();
                        List<string> ActMillist = new List<string>();
                        string DelQty = "";
                        string IndDate = "";
                        string AvgMileage = "";
                        string MainQty = "";
                        string Cans = "";
                        int count = 0;
                        foreach (DataRow dr in dtReport.Rows)
                        {
                            string DeliveryQty = dr["closing"].ToString();
                            string isuued = dr["isuued"].ToString();
                            DelQty += DeliveryQty + ",";
                            MainQty += isuued + ",";
                            int can10 = 0;
                            int.TryParse(dr["clo10"].ToString(), out can10);
                            int can20 = 0;
                            int.TryParse(dr["clo20"].ToString(), out can20);
                            int can40 = 0;
                            int.TryParse(dr["clo40"].ToString(), out can40);
                            int canbal = 0;
                            canbal = can10 + can20 + can40;
                            string clobal = canbal.ToString();
                            AvgMileage += clobal + ",";

                            int issue10 = 0;
                            int.TryParse(dr["issue10"].ToString(), out issue10);
                            int issue20 = 0;
                            int.TryParse(dr["issu20"].ToString(), out issue20);
                            int issue40 = 0;
                            int.TryParse(dr["issu40"].ToString(), out issue40);
                            int canIssuedbal = 0;
                            canIssuedbal = issue10 + issue20 + issue40;
                            string Cloissuedbal = canIssuedbal.ToString();
                            Cans += Cloissuedbal + ",";
                            string IndentDate = dr["doe"].ToString();
                            DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                            string ChangedTime = dtIndentDate.ToString("dd/MMM");
                            IndDate += ChangedTime + ",";
                            count++;
                        }
                        AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                        IndDate = IndDate.Substring(0, IndDate.Length - 1);
                        DelQty = DelQty.Substring(0, DelQty.Length - 1);
                        MainQty = MainQty.Substring(0, MainQty.Length - 1);
                        Cans = Cans.Substring(0, Cans.Length - 1);
                        //Deliverlist.Add(DelQty);
                        //Deliverlist.Add(AvgMileage);
                        //Deliverlist.Add(MainQty);
                        //Deliverlist.Add(Cans);
                        //Statuslist.Add("Crates Clo Bal");
                        //Statuslist.Add("Cans Clo Bal");
                        //Statuslist.Add("Issued Crates");
                        //Statuslist.Add("Issued Cans");
                        getLineChart.IndentDate = IndDate;
                        getLineChart.cratesissue = DelQty;
                        getLineChart.crtesclo = MainQty;
                        getLineChart.cansissue = Cans;
                        getLineChart.cansclo = AvgMileage;

                        //getLineChart.DeliveryQty = Deliverlist;
                        getLineChart.Status = Statuslist;
                        getLineChart.ActMileage = ActMillist;
                        LineChartValuelist.Add(getLineChart);
                    }
                }
                string response = GetJson(LineChartValuelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetLineChart_agentduetransactions(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();

                string Fmdate = context.Request["startDate"];
                string AgentName = context.Request["AgentName"];
                string RouteName = context.Request["RouteName"];
                string SalesOffice = context.Request["SalesOffice"];
                string Type = context.Request["Type"];
                string classificationtype = context.Request["classificationtype"];
                string salestype = context.Request["salestype"];
                string ddldatatype = context.Request["ddldatatype"];
                ////string Fmdate = context.Request["txtFromdate"];
                DateTime fmdate = Convert.ToDateTime(Fmdate);
                string CTime = fmdate.ToString();
                DateTime dtFrmDate = Convert.ToDateTime(CTime);
                DateTime FromDate = DateTime.Now;
                string toDate = context.Request["endDate"];
                //string toDate = context.Request["txtTodate"];
                DateTime tDate = Convert.ToDateTime(toDate);
                string CTTime = tDate.ToString();
                DateTime dttoDate = Convert.ToDateTime(CTTime);
                DateTime Enddate = DateTime.Now;
                string time = dtFrmDate.ToString("dd-MM-yyyy HH:mm");//
                string[] fromdatestrig = time.Split(' ');
                if (fromdatestrig.Length > 1)
                {
                    if (fromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = fromdatestrig[0].Split('-');
                        string[] times = fromdatestrig[1].Split(':');
                        FromDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                string endtime = dttoDate.ToString("dd-MM-yyyy HH:mm");
                string[] endfromdatestrig = endtime.Split(' ');
                if (endfromdatestrig.Length > 1)
                {
                    if (endfromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = endfromdatestrig[0].Split('-');
                        string[] times = endfromdatestrig[1].Split(':');
                        Enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                List<LineChartValuesclass> LineChartValuelist = new List<LineChartValuesclass>();
                DataTable dtReport = new DataTable();
                if (ddldatatype == "Day Wise")
                {
                    if (Type == "Sales Office Wise")
                    {
                        cmd = new MySqlCommand("SELECT duetransactions.IndentDate, SUM(duetransactions.SaleValue) AS SaleValue, SUM(duetransactions.ClosingBalance) AS ClosingBalance FROM duetransactions INNER JOIN branchdata ON duetransactions.AgentId = branchdata.sno WHERE (duetransactions.IndentDate BETWEEN @d1 AND @d2) AND (duetransactions.SalesOfficeId = @BranchID) AND (branchdata.SalesType = @SalesType) GROUP BY duetransactions.SalesOfficeId, duetransactions.IndentDate ORDER BY duetransactions.IndentDate");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@BranchID", SalesOffice);
                        cmd.Parameters.Add("@SalesType", classificationtype);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (Type == "Route Wise")
                    {
                        cmd = new MySqlCommand("SELECT duetransactions.IndentDate, SUM(duetransactions.SaleValue) AS SaleValue, SUM(duetransactions.ClosingBalance) AS ClosingBalance FROM duetransactions INNER JOIN branchdata ON duetransactions.AgentId = branchdata.sno WHERE (duetransactions.IndentDate BETWEEN @d1 AND @d2) AND (duetransactions.RouteId = @RouteId) AND (branchdata.SalesType = @SalesType) GROUP BY duetransactions.RouteId, duetransactions.IndentDate ORDER BY duetransactions.IndentDate");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@RouteId", RouteName);
                        cmd.Parameters.Add("@SalesType", classificationtype);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (Type == "Agent Wise")
                    {
                        cmd = new MySqlCommand("SELECT Sno, SalesOfficeId, RouteId, AgentId, IndentDate, EntryDate, OppBalance, SaleQty, SaleValue, ReceivedAmount, ClosingBalance, DiffAmount FROM duetransactions WHERE (IndentDate BETWEEN @d1 AND @d2) AND (AgentId = @AgentId) ORDER BY IndentDate");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@AgentId", AgentName);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                    }
                    if (dtReport.Rows.Count > 0)
                    {
                        LineChartValuesclass getLineChart = new LineChartValuesclass();
                        List<string> unitlist = new List<string>();
                        List<string> Deliverlist = new List<string>();
                        List<string> Datelist = new List<string>();
                        List<string> Statuslist = new List<string>();
                        List<string> ActMillist = new List<string>();
                        string MainQty = "";
                        string DelQty = "";
                        string IndDate = "";
                        string AvgMileage = "";
                        double avgSaleQty = 0;
                        int count = 0;
                        foreach (DataRow dr in dtReport.Rows)
                        {
                            string DeliveryQty = dr["ClosingBalance"].ToString();
                            DelQty += DeliveryQty + ",";
                            string SaleValue = dr["SaleValue"].ToString();
                            AvgMileage += SaleValue + ",";
                            double milltr = 0;
                            double.TryParse(dr["ClosingBalance"].ToString(), out milltr);
                            avgSaleQty += milltr;
                            //unitlist.Add(dr["unitQty"].ToString());
                            //Deliverlist.Add(dr["DeliveryQty"].ToString());
                            string IndentDate = dr["IndentDate"].ToString();
                            DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                            string ChangedTime = dtIndentDate.ToString("dd/MMM");
                            IndDate += ChangedTime + ",";
                            count++;
                            //Datelist.Add(ChangedTime);
                        }

                        AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                        IndDate = IndDate.Substring(0, IndDate.Length - 1);
                        DelQty = DelQty.Substring(0, DelQty.Length - 1);

                        getLineChart.IndentDate = IndDate;
                        getLineChart.aqty = AvgMileage;
                        getLineChart.dqty = DelQty;
                        getLineChart.Sstatus = salestype;
                        //Deliverlist.Add(DelQty);
                        //Deliverlist.Add(AvgMileage);
                       
                        //Statuslist.Add("Due");
                        //Statuslist.Add("Sale Value");
                        //Statuslist.Add(salestype);
                        //getLineChart.IndentDate = IndDate;
                        //getLineChart.DeliveryQty = Deliverlist;
                        
                        //getLineChart.Status = Statuslist;
                        //getLineChart.ActMileage = ActMillist;
                        LineChartValuelist.Add(getLineChart);
                    }
                }
                string response = GetJson(LineChartValuelist);
                context.Response.Write(response);
            }
            catch
            {
            }
        }
        private void GetLineChart_classificationindentreport(HttpContext context)
        {
            try
            {
                vdm = new VehicleDBMgr();

                string Fmdate = context.Request["startDate"];
                string SalesType = context.Request["classificationtype"];
                string SalesOffice = context.Request["SalesOffice"];
                string salestype = context.Request["salestype"];
                string ddldatatype = context.Request["ddldatatype"];
                string Type = context.Request["Type"];
                DateTime fmdate = Convert.ToDateTime(Fmdate);
                string CTime = fmdate.ToString();
                DateTime dtFrmDate = Convert.ToDateTime(CTime);
                DateTime FromDate = DateTime.Now;
                string toDate = context.Request["endDate"];
                DateTime tDate = Convert.ToDateTime(toDate);
                string CTTime = tDate.ToString();
                DateTime dttoDate = Convert.ToDateTime(CTTime);
                DateTime Enddate = DateTime.Now;
                string time = dtFrmDate.ToString("dd-MM-yyyy HH:mm");//
                string[] fromdatestrig = time.Split(' ');
                if (fromdatestrig.Length > 1)
                {
                    if (fromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = fromdatestrig[0].Split('-');
                        string[] times = fromdatestrig[1].Split(':');
                        FromDate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                string endtime = dttoDate.ToString("dd-MM-yyyy HH:mm");
                string[] endfromdatestrig = endtime.Split(' ');
                if (endfromdatestrig.Length > 1)
                {
                    if (endfromdatestrig[0].Split('-').Length > 0)
                    {
                        string[] dates = endfromdatestrig[0].Split('-');
                        string[] times = endfromdatestrig[1].Split(':');
                        Enddate = new DateTime(int.Parse(dates[2]), int.Parse(dates[1]), int.Parse(dates[0]), int.Parse(times[0]), int.Parse(times[1]), 0);
                    }
                }
                List<LineChartValuesclass> LineChartValuelist = new List<LineChartValuesclass>();
                DataTable dtReport = new DataTable();
                if (Type == "Sales Office Wise")
                {
                    if (ddldatatype == "Day Wise")
                    {
                        cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID) AND (branchdata.SalesType = @SalesType)  GROUP BY  DATE(indents.I_date)");
                        cmd.Parameters.Add("@d1", CargoManagementSystem.DateConverter.GetLowDate(FromDate.AddDays(-1)));
                        cmd.Parameters.Add("@d2", CargoManagementSystem.DateConverter.GetHighDate(Enddate.AddDays(-1)));
                        cmd.Parameters.Add("@BranchID", SalesOffice);
                        cmd.Parameters.Add("@SalesType", SalesType);
                        dtReport = vdm.SelectQuery(cmd).Tables[0];
                        if (dtReport.Rows.Count > 0)
                        {
                            LineChartValuesclass getLineChart = new LineChartValuesclass();
                            List<string> unitlist = new List<string>();
                            List<string> Deliverlist = new List<string>();
                            List<string> Datelist = new List<string>();
                            List<string> Statuslist = new List<string>();
                            List<string> ActMillist = new List<string>();
                            string DelQty = "";
                            string IndDate = "";
                            string AvgMileage = "";
                            double avgSaleQty = 0;
                            int count = 0;
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string DeliveryQty = dr["DeliveryQty"].ToString();
                                DelQty += DeliveryQty + ",";
                                double milltr = 0;
                                double.TryParse(dr["DeliveryQty"].ToString(), out milltr);
                                avgSaleQty += milltr;
                                string IndentDate = dr["I_date"].ToString();
                                DateTime now = Convert.ToDateTime(IndentDate).AddDays(1);
                                string dayname = now.DayOfWeek.ToString();
                                DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                                string ChangedTime = dtIndentDate.ToString("dd");
                                string newdate = ChangedTime + "/" + dayname;
                                IndDate += newdate + ",";
                                count++;
                            }
                            double avg = 0;
                            avg = (avgSaleQty / count);
                            avg = Math.Round(avg, 2);
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string TodayMileage = dr["DeliveryQty"].ToString();
                                if (TodayMileage != "0")
                                {
                                    AvgMileage += avg.ToString() + ",";
                                }
                            }
                            AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                            IndDate = IndDate.Substring(0, IndDate.Length - 1);
                            DelQty = DelQty.Substring(0, DelQty.Length - 1);
                            //Deliverlist.Add(DelQty);
                            getLineChart.IndentDate = IndDate;
                            getLineChart.aqty = AvgMileage;
                            getLineChart.dqty = DelQty;
                            getLineChart.Sstatus = salestype;
                            //Deliverlist.Add(AvgMileage);
                            //Statuslist.Add("Sales");
                            //Statuslist.Add(salestype);
                            //getLineChart.IndentDate = IndDate;
                            //getLineChart.DeliveryQty = Deliverlist;
                            //getLineChart.Status = Statuslist;
                            //getLineChart.ActMileage = ActMillist;
                            LineChartValuelist.Add(getLineChart);
                        }
                        string response = GetJson(LineChartValuelist);
                        context.Response.Write(response);
                    }
                    else
                    {
                        DataTable Report = new DataTable();
                        DateTime firstmonth = new DateTime();
                        DateTime lastmonth = new DateTime();
                        Enddate = Enddate.AddMonths(1);
                        TimeSpan dateSpan = Enddate.Subtract(FromDate);
                        int years = (dateSpan.Days / 365);
                        int months = ((dateSpan.Days % 365) / 31) + (years * 12);
                        Report.Columns.Add("SNo");
                        Report.Columns.Add("Date");
                        Report.Columns.Add("Qty");
                        int N = 0;
                        int i = 1;
                        if (months != 0)
                        {
                            for (int j = 0; j < months; j++)
                            {
                                firstmonth = GetLowMonthRetrive(FromDate.AddMonths(j));
                                lastmonth = GetHighMonth(firstmonth);
                                cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchmappingtable ON branchdata.sno = branchmappingtable.SubBranch WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchdata.SalesType = @SalesType) AND (branchmappingtable.SuperBranch = @BranchID) GROUP BY branchmappingtable.SuperBranch ");
                                //cmd = new MySqlCommand("SELECT ROUND(SUM(indents_subtable.unitQty), 2) AS unitQty, ROUND(SUM(indents_subtable.DeliveryQty), 2) AS DeliveryQty, indents.I_date, indents_subtable.DTripId, branchroutes.BranchID FROM indents_subtable INNER JOIN indents ON indents_subtable.IndentNo = indents.IndentNo INNER JOIN branchdata ON indents.Branch_id = branchdata.sno INNER JOIN branchroutesubtable ON branchdata.sno = branchroutesubtable.BranchID INNER JOIN branchroutes ON branchroutesubtable.RefNo = branchroutes.Sno WHERE (indents.I_date BETWEEN @d1 AND @d2) AND (indents_subtable.DeliveryQty > 0) AND (branchroutes.BranchID = @BranchID) AND (branchdata.SalesType = @SalesType)");
                                cmd.Parameters.Add("@BranchID", SalesOffice);
                                DateTime dtF = firstmonth.AddDays(-1);
                                cmd.Parameters.Add("@d1", dtF);
                                cmd.Parameters.Add("@d2", lastmonth);
                                cmd.Parameters.Add("@SalesType", SalesType);
                                TimeSpan dateSpan2 = lastmonth.Subtract(dtF);
                                int NoOfdays = dateSpan2.Days;
                                DataTable dtAgent = vdm.SelectQuery(cmd).Tables[0];
                                string ChangedTime1 = firstmonth.ToString("MMM/yyyy");
                                string Changedt = firstmonth.ToString("MMM");
                                foreach (DataRow dr in dtAgent.Rows)
                                {
                                    DataRow newrow = Report.NewRow();
                                    newrow["SNo"] = i++.ToString();
                                    newrow["Date"] = ChangedTime1;
                                    double delQty = 0;
                                    double.TryParse(dr["DeliveryQty"].ToString(), out delQty);
                                    double qty = 0;
                                    qty = delQty / NoOfdays;
                                    newrow["Qty"] = qty.ToString("F2");
                                    Report.Rows.Add(newrow);
                                }
                            }
                        }
                        dtReport = Report;
                        if (dtReport.Rows.Count > 0)
                        {
                            LineChartValuesclass getLineChart = new LineChartValuesclass();
                            List<string> unitlist = new List<string>();
                            List<string> Deliverlist = new List<string>();
                            List<string> Datelist = new List<string>();
                            List<string> Statuslist = new List<string>();
                            List<string> ActMillist = new List<string>();
                            string DelQty = "";
                            string IndDate = "";
                            string AvgMileage = "";
                            double avgSaleQty = 0;
                            int count = 0;
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string DeliveryQty = dr["Qty"].ToString();
                                DelQty += DeliveryQty + ",";
                                double milltr = 0;
                                double.TryParse(dr["Qty"].ToString(), out milltr);
                                avgSaleQty += milltr;
                                string IndentDate = dr["Date"].ToString();
                                //DateTime now = Convert.ToDateTime(IndentDate).AddDays(1);
                                //string dayname = now.DayOfWeek.ToString();
                                //DateTime dtIndentDate = Convert.ToDateTime(IndentDate).AddDays(1);
                                //string ChangedTime = dtIndentDate.ToString("dd");
                                //string newdate = ChangedTime + "/" + dayname;
                                IndDate += IndentDate + ",";
                                count++;
                            }
                            double avg = 0;
                            avg = (avgSaleQty / count);
                            avg = Math.Round(avg, 2);
                            foreach (DataRow dr in dtReport.Rows)
                            {
                                string TodayMileage = dr["Qty"].ToString();
                                if (TodayMileage != "0")
                                {
                                    AvgMileage += avg.ToString() + ",";
                                }
                            }
                            AvgMileage = AvgMileage.Substring(0, AvgMileage.Length - 1);
                            IndDate = IndDate.Substring(0, IndDate.Length - 1);
                            DelQty = DelQty.Substring(0, DelQty.Length - 1);
                            getLineChart.IndentDate = IndDate;
                            getLineChart.aqty = AvgMileage;
                            getLineChart.dqty = DelQty;
                            getLineChart.Sstatus = salestype;
                            //Deliverlist.Add(DelQty);
                            //Deliverlist.Add(AvgMileage);
                            //Statuslist.Add("Sales");
                            //Statuslist.Add(salestype);
                            //getLineChart.IndentDate = IndDate;
                            //getLineChart.DeliveryQty = Deliverlist;
                            //getLineChart.Status = Statuslist;
                            //getLineChart.ActMileage = ActMillist;
                            LineChartValuelist.Add(getLineChart);
                        }
                        string response = GetJson(LineChartValuelist);
                        context.Response.Write(response);
                    }
                }
            }
            catch
            {
            }
        }
        private void checkloginstatus(HttpContext context)
        {
            if (context.Session["branch"] == null || context.Session["branch"] == "")
            {
                string respnceString = GetJson("NotValid");
                context.Response.Write(respnceString);
            }
            else
            {
                string respnceString = GetJson("valid");
                context.Response.Write(respnceString);
            }
        }
    }
}