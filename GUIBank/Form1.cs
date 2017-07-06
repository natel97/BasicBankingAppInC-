using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIBank
{

    public partial class Form1 : Form
    {
        List<account> acct = new List<account>()
            {
                new savings("Nathanial Lubitz", 10000000, 100.00, "608 East Main Ave, Frazee, MN 56544", "S382293433923"),
                new checking("Nathanial Lubitz", 10000001, 1000.00, "608 East Main Ave, Frazee, MN 56544", "S382293433923"),
                new market("Nathanial Lubitz",10000002, 100000.00,"608 East Main Ave, Frazee, MN 56544","S239848325")
            };

        public double amnt;
        public long acctFrom;
        long acctTo;
        byte currentday = 1;
        long nextAcct = 10000003;
        savings s = new savings("Nathanial Lubitz", 10000000, 100.00, "608 East Main Ave, Frazee, MN 56544", "S382293433923");
        checking c = new checking("Nathanial Lubitz", 10000001, 1000.00, "608 East Main Ave, Frazee, MN 56544", "S382293433923");
        market m = new market("Nathanial Lubitz", 10000002, 100000.00, "608 East Main Ave, Frazee, MN 56544", "S239848325");


        public Form1()
        {
            InitializeComponent();
            iAcct.KeyDown += new KeyEventHandler(iAcct_KeyDown);
            iDeposit.KeyDown += new KeyEventHandler(iDeposit_KeyDown);
            iWithdrawl.KeyDown += new KeyEventHandler(iWithdrawl_KeyDown);
            iTransfer.KeyDown += new KeyEventHandler(iTransfer_KeyDown);
            iTAccount.KeyDown += new KeyEventHandler(iTAccount_KeyDown);
            iName.KeyDown += new KeyEventHandler(iName_KeyDown);
            iAddress.KeyDown += new KeyEventHandler(iAddress_KeyDown);
            iID.KeyDown += new KeyEventHandler(iID_KeyDown);
            iChe.KeyDown += new KeyEventHandler(iChe_KeyDown);
            iSav.KeyDown += new KeyEventHandler(iSav_KeyDown);
            t4acct.KeyDown += new KeyEventHandler(t4acct_KeyDown);
            t3acct.KeyDown += new KeyEventHandler(t3acct_KeyDown);
            iAcct.Focus();
            label7.Text = "Today is the " + currentday + "th";
            this.ActiveControl = iAcct;
            
        }
        void t4acct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    acctFrom = Convert.ToInt64(t4acct.Text);
                    account a = acct.Find(i => i.accountID == acctFrom);
                    if (a == null)
                    {
                    billname.Enabled = false;
                    billamnt.Enabled = false;
                    billlist.Enabled = false;
                    addbill.Enabled = false;
                    paybill.Enabled = false;
                    }
                    else
                    {
                    billname.Enabled = true;
                    billamnt.Enabled = true;
                    billlist.Enabled = true;
                    addbill.Enabled = true;
                    paybill.Enabled = true;
                    label12.Text = a.name;
                    for (int x = 0; x < billlist.Items.Count; x++)
                        billlist.Items.Clear();
                    for (int x = 0; x < a.bill.Count; x++)
                        billlist.Items.Add(a.bill[x]);
                }
                    e.SuppressKeyPress = true;
                    e.Handled = true;
            }
        }
        void iAcct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acctFrom = Convert.ToInt64(iAcct.Text);
                account a = acct.Find(i => i.accountID == acctFrom);
                if (a == null)
                {
                    lblinfo.Text = "Sorry, the account does not exist";
                }
                else
                {
                    lblinfo.Text = "Account number: " + a.accountID + "\nName: " + a.name + "\nAddress: " + a.address + "\nState Issued ID: " + a.GovID + "\n\nAvaliable Balance: $" + a.balance + "\nAccount type" + a.accttype;
                    if (a.accttype == "Market")
                { radioButton1.Enabled = false; radioButton2.Enabled = false; radioButton3.Enabled = false; }
                else
                { radioButton1.Enabled = true; radioButton2.Enabled = true; radioButton3.Enabled = true; }
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
                radioButton1.Checked = true;
                
            }
        }
        void iDeposit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
                radioButton2.Checked = true;
        }
        void iWithdrawl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Down)
                radioButton3.Checked = true;
            if (e.KeyCode == Keys.Up)
                radioButton1.Checked = true;
        }
        void iTAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
                radioButton2.Checked = true;
        }
        void iTransfer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = iTAccount;
                e.SuppressKeyPress = true;
                e.Handled = true;
                iTAccount.Focus();
            }
            if (e.KeyCode == Keys.Up)
                radioButton2.Checked = true;
        }

        void iName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.ActiveControl = iAddress;
                e.SuppressKeyPress = true;
                e.Handled = true;
                iAddress.Focus();
            }
        }
        void iAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.ActiveControl = iID;
                e.SuppressKeyPress = true;
                e.Handled = true;
                iID.Focus();
            }
            if (e.KeyCode == Keys.Up)
                this.ActiveControl = iName;
        }
        void iID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.ActiveControl = checkBox1;
                e.SuppressKeyPress = true;
                e.Handled = true;
                checkBox1.Focus();
            }
            if (e.KeyCode == Keys.Up)
                this.ActiveControl = iAddress;
        }
        void iSav_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                this.ActiveControl = checkBox2;
                e.SuppressKeyPress = true;
                e.Handled = true;
                checkBox2.Focus();
            }
            if (e.KeyCode == Keys.Up)
                this.ActiveControl = iID;
        }
        void iChe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
                this.ActiveControl = checkBox1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                iDeposit.Enabled = true;
                this.ActiveControl = iDeposit;
            }
            else
                iDeposit.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            acctFrom = Convert.ToInt64(iAcct.Text);
            account a = acct.Find(i => i.accountID == acctFrom);
            if (radioButton1.Checked)
            {
                try
                {
                    amnt = Convert.ToDouble(iDeposit.Text);
                    a.balance += amnt;
                    lblMsg.Text = a.name + "'s account balance has changed from $" + (a.balance - amnt) + " to $" + a.balance + "!";
                    iDeposit.Text = "";
                    radioButton1.Checked = false;
                    lblinfo.Text = "Account number: " + a.accountID + "\nName: " + a.name + "\nAddress: " + a.address + "\nState Issued ID: " + a.GovID + "\n\nAvaliable Balance: $" + a.balance;

                }
                catch
                {
                    lblMsg.Text = "An error has occured.. :(";
                }
            }
            if (radioButton2.Checked)
            {
                try
                {
                    amnt = Convert.ToDouble(iWithdrawl.Text);
                    if (a.balance - amnt >= a.minimumbal)
                    {
                        a.balance -= amnt;
                        lblMsg.Text = a.name + "'s account balance has changed from $" + (a.balance + amnt) + " to $" + a.balance + "!";
                        iWithdrawl.Text = "";
                        radioButton2.Checked = false;
                        lblinfo.Text = "Account number: " + a.accountID + "\nName: " + a.name + "\nAddress: " + a.address + "\nState Issued ID: " + a.GovID + "\n\nAvaliable Balance: $" + a.balance;
                    }
                    else
                        lblMsg.Text = "Balance too low";
                }
                catch
                {
                    lblMsg.Text = "An error has occured.. :(";
                }
            }
            if (radioButton3.Checked)
            {
                try
                {
                    acctTo = Convert.ToInt64(iTAccount.Text);
                    account b = acct.Find(h => h.accountID == acctTo);
                    if (b == null)
                    {
                        lblMsg.Text = "Transfer account not found!";
                        iTAccount.Text = "";
                        this.ActiveControl = iTAccount;
                    }
                    else
                    {
                        amnt = Convert.ToDouble(iTransfer.Text);
                        if (a.balance < amnt)
                        {
                            lblMsg.Text = "Insufficent funds :(";
                            this.ActiveControl = iTransfer;
                        }
                        else
                        {
                            a.balance -= amnt;
                            b.balance += amnt;
                            lblMsg.Text = a.name + "'s account balance has changed from $" + (a.balance + amnt) + " to $" + a.balance + "!\n" + b.name + "'s account balance has been credited $" + amnt;
                            iTransfer.Text = "";
                            iTAccount.Text = "";
                            radioButton3.Checked = false;
                            lblinfo.Text = "Account number: " + a.accountID + "\nName: " + a.name + "\nAddress: " + a.address + "\nState Issued ID: " + a.GovID + "\n\nAvaliable Balance: $" + a.balance;
                        }
                    }


                    this.ActiveControl = iAcct;
                }
                catch { lblMsg.Text = "error"; }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (radioButton2.Checked)
                {
                    iWithdrawl.Enabled = true;
                    this.ActiveControl = iWithdrawl;
                }
                else
                    iWithdrawl.Enabled = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (radioButton3.Checked)
                {
                    iTAccount.Enabled = true;
                    iTransfer.Enabled = true;
                    this.ActiveControl = iTransfer;
                }
                else
                {
                    iTransfer.Enabled = false;
                    iTAccount.Enabled = false;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                iSav.Enabled = true;
                this.ActiveControl = iSav;
            }
            else
                iSav.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                iChe.Enabled = true;
                this.ActiveControl = iChe;
            }
            else
                iChe.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            try
            {
                if (iName.Text != "")
                {
                    if (iAddress.Text != "")
                    {
                        if (iID.Text != "")
                        {
                            if (checkBox1.Checked)
                            {
                                if (Convert.ToDouble(iSav.Text) > s.minimumdown)
                                {
                                    acct.Add(new savings(iName.Text, nextAcct, Convert.ToDouble(iSav.Text), iAddress.Text, iID.Text));
                                    label6.Text += iName.Text + "'s savings account has been created!\nccount number : " + nextAcct + "\n";
                                    nextAcct++;
                                    checkBox1.Checked = false;
                                    iSav.Text = "";
                                }
                                else
                                {
                                    label6.Text = "Error Occured! Balance too low";
                                    return;
                                }
                            }

                            if (checkBox2.Checked)
                            {
                                if (Convert.ToDouble(iChe.Text) >= c.minimumdown)
                                {
                                    acct.Add(new checking(iName.Text, nextAcct, Convert.ToDouble(iChe.Text), iAddress.Text, iID.Text));
                                    label6.Text += iName.Text + "'s checking account has been created!\nAccount number : " + nextAcct + "\n";
                                    nextAcct++;
                                    iChe.Text = "";
                                    checkBox2.Checked = false;
                                }
                                else
                                {
                                    label6.Text = "Error Occured. Plese Check Balance";
                                    return;
                                }
                            }
                            if (checkBox3.Checked)
                            {
                                if (Convert.ToDouble(iMM.Text) >= m.minimumdown)
                                {
                                    acct.Add(new market(iName.Text, nextAcct, Convert.ToDouble(iMM.Text), iAddress.Text, iID.Text));
                                    label6.Text += iName.Text + "'s Money Market account has been created!\nAccount number : " + nextAcct + "\n";
                                    nextAcct++;
                                    iChe.Text = "";
                                    checkBox2.Checked = false;
                                }
                                else
                                {
                                    label6.Text = "Error Occured. Plese Check Balance";
                                    return;
                                }
                            }
                        }
                        else this.ActiveControl = iID;
                    }
                    else this.ActiveControl = iAddress;
                }
                else this.ActiveControl = iName;

            }
            catch { label6.Text = "Invalid input!"; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                iMM.Enabled = true;
                this.ActiveControl = iMM;
            }
            else
                iMM.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 100.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void MMessage_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 20.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 40.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }
        

    }

    private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 60.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 80.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 120.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 140.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 160.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t3acct.Text);
                account b = acct.Find(i => i.accountID == acctFrom);
                b.balance -= 2000.00;
                label11.Text = b.name + "'s \naccount balance is now " + b.balance;
            }
            catch { int a = 22; }

        }




        void textbox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acctFrom = Convert.ToInt64(iAcct.Text);
                account a = acct.Find(i => i.accountID == acctFrom);
                if (a == null)
                {
                    MMessage.Text = "Sorry, the account does not exist";
                }
                else
                {
                    MMessage.Text = "Account number: " + a.accountID + "\nName: " + a.name + "\nAddress: " + a.address + "\nState Issued ID: " + a.GovID + "\n\nAvaliable Balance: $" + a.balance + "\nAccount type" + a.accttype;
                }
                e.SuppressKeyPress = true;
                e.Handled = true;
                if (a.accttype == "Market")
                { radioButton1.Enabled = false; radioButton2.Enabled = false; radioButton3.Enabled = false; }
                else
                { radioButton1.Enabled = true; radioButton2.Enabled = true; radioButton3.Enabled = true; }
            }
        }

       /* public void boxupdate(int choice)
        {
            if (choice == 1)
            {
                button
            }
        }
        */

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void iAcct_TextChanged(object sender, EventArgs e)
        {

        }

        private void t3acct_TextChanged(object sender, EventArgs e)
        {

        }
        private void t3acct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {try
                {
                    acctFrom = Convert.ToInt64(t3acct.Text);
                    account b = acct.Find(i => i.accountID == acctFrom);
                    if (b == null|| b.accttype == "Market")
                    {
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                        button8.Enabled = false;
                        button9.Enabled = false;
                        button10.Enabled = false;
                        button11.Enabled = false;

                    }
                    else
                    {
                        
                        {
                            button3.Enabled = true;
                            button4.Enabled = true;
                            button5.Enabled = true;
                            button6.Enabled = true;
                            button7.Enabled = true;
                            button8.Enabled = true;
                            button9.Enabled = true;
                            button10.Enabled = true;
                            button11.Enabled = true;
                            
                        }
                    }
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                catch { int a = 30; }
            }
        }

        private void addbill_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t4acct.Text);
                account a = acct.Find(i => i.accountID == acctFrom);
                a.bill.Add(new bills(billname.Text, Convert.ToDouble(billamnt.Text)));
                billlist.Items.Add(new bills(billname.Text, Convert.ToDouble(billamnt.Text)));
            }
            catch
            {
                billamnt.Text = "";
            }
        }

        private void paybill_Click(object sender, EventArgs e)
        {
            try
            {
                acctFrom = Convert.ToInt64(t4acct.Text);
                account a = acct.Find(i => i.accountID == acctFrom);
                bills b = (bills)billlist.SelectedItem;
                a.balance -= b.amnt;
                label12.Text = "Account updated! From " + (a.balance + b.amnt) + " to " + a.balance;
            }
            catch
            {
                billamnt.Text = "";
            }
        }
    }
}
    abstract class account
    {
    public List<bills> bill = new List<bills> { new bills("Default", 10.00) };
        public string accttype;
        public string name;
        public long accountID;
        public double balance;
        public string address;
        public string GovID;
        public double minimumbal = 0;
        public double minimumdown = 0;
        public double interest = 1;
        public double overdraft = 0;
        public double closing = 0;
        public byte compoundday = 0;
        public double monthlyfee = 0;
        public virtual bool compound(byte currentday)
        {
            if (currentday == compoundday)
            {
                balance *= interest;
                return true;
            }
            else
                return false;
        }
    }
class savings : account
{
    private double strToDbl;
    public savings(string Name, long AccountID, double StartingBalance, string Address, string govID)
    {
        name = Name;
        accountID = AccountID;
        balance = StartingBalance;
        address = Address;
        GovID = govID;
        minimumdown = 100.00;
        minimumbal = 50.00;
        interest = 1.01;

    }
    public bool deposit(string strAmnt)
    {
        try
        {
            strToDbl = Convert.ToDouble(strAmnt);
            balance += strToDbl;
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool withdrawl(string strAmnt)
    {
        try
        {
            strToDbl = Convert.ToDouble(strAmnt);
            if (balance < strToDbl)
            {
                return false;
            }
            else
            {
                balance -= strToDbl;
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
class checking : account
{
    private double strToDbl;
    public checking(string Name, long AccountID, double StartingBalance, string Address, string govID)
    {
        name = Name;
        accountID = AccountID;
        balance = StartingBalance;
        address = Address;
        GovID = govID;
        minimumdown = 100.00;
        monthlyfee = 20.00;
        overdraft = 35.00;
        accttype = "Checking";
    }
    public bool deposit(string strAmnt)
    {
        try
        {
            strToDbl = Convert.ToDouble(strAmnt);
            balance += strToDbl;
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool withdrawl(string strAmnt)
    {
        try
        {
            strToDbl = Convert.ToDouble(strAmnt);
            if (balance < strToDbl)
            {
                balance -= strToDbl;
                balance -= overdraft;
                return true;
            }
            else
            {
                balance -= strToDbl;
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}
    
    class market : account
    {
        public market(string Name, long AccountID, double StartingBalance, string Address, string govID)
        {
            name = Name;
            accountID = AccountID;
            balance = StartingBalance;
            address = Address;
            GovID = govID;
            interest = 1.02;
            minimumdown = 25000.00;
            minimumbal = 10000.00;
            closing = 50.00;
            accttype = "Market";

    }
    public bool deposit(string a)
        {
            return false;
        }
        public bool withdrawl(string a)
        {
            try
            {
                double b = Convert.ToDouble(a);
                if (b > balance - 10000)
                    return false;
                else
                {
                    balance -= b;
                    return true;
                }
            }
            catch { return false; }
        }
        public override bool compound(byte currentday)
        {
                return false;
        }
    }
class bills
{
    public string name;
    public double amnt;
    public bills(string nam, double amn)
    {
        name = nam;
        amnt = amn;
    }
    public override string ToString()
    {
        // Generates the text shown in the combo box
        return name;
    }
}
