<%@ Page Title="" Language="C#" MasterPageFile="~/demo/admincommonsections.master" AutoEventWireup="true" CodeFile="AddClient.aspx.cs" Inherits="admin_AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">
        <div class="col-md-12">
        <div class="card">
            <%--Button For select panel--%>
            <div class="btn-group bg-dark">
                <asp:Button ID="btn_paneladdadmin" runat="server" Text="Add Clients" style="background-color: #FF6500;" CssClass="btn btn-info text-light" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <%--Add category --%>

            <div class="card-body">
                <div class="row mb-4" style="height:70px">
                    <label class="col-md-2">Client Name</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                        
                    </div>
                     <asp:RequiredFieldValidator ID="require_adminnme" runat="server" ValidationGroup="CLIENT" ErrorMessage="Enter Client name" ControlToValidate="txtname" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="row mb-4" style="height:70px">
                    <label class="col-md-2">Client Location</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txtloc" runat="server" class="form-control"></asp:TextBox>
                       
                    </div>
                   <asp:RequiredFieldValidator ID="require_adminemail" runat="server" ValidationGroup="CLIENT" ErrorMessage="Enter Client's Location" ControlToValidate="txtloc" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="row mb-4" style="height:70px">
                    
                        <label class="col-md-2">Amount</label>                   
                    <div class="col-md-4">
                        <asp:TextBox ID="txtamount" runat="server" class="form-control"></asp:TextBox>
                                               
                    </div>
                    <asp:RequiredFieldValidator ID="require_adminpass" runat="server" ValidationGroup="CLIENT" ErrorMessage="Enter Amount" ControlToValidate="txtamount" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="row mb-4" style="height:70px">
                    <label class="col-md-2">Task Description</label>
                    <div class="col-md-4">
                        <asp:TextBox ID="txttask" runat="server" class="form-control"></asp:TextBox>
                        <br />
                        
                    </div>
                    <asp:RequiredFieldValidator ID="require_adminpassrepeat" runat="server" ValidationGroup="CLIENT" ErrorMessage="Describe Task" ControlToValidate="txttask" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="card-footer mt-5">
                    <div class="offset-2">
                        <asp:LinkButton ID="LinkButton1" runat="server" ValidationGroup="CLIENT" style="text-decoration: none" class="px-3 py-2 rounded" Text="ADD CLIENT" BackColor="#343A40" BorderStyle="None" ForeColor="White" OnClick="LinkButton1_Click"></asp:LinkButton>
                    </div>                   
                </div>
            </div>
              <div class="btn-group bg-dark">
                <asp:Button ID="Button2" runat="server" Text="Contact Person" style="background-color: #FF6500;" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
              </div>
            <asp:Panel ID="Panel1" runat="server">
             
                <div class="card-body">
                      <asp:Panel ID="panel_addamin_warning" runat="server" Visible="false">
                        <br />
                        <div class="alert alert-danger text-center">
                            <asp:Label ID="lbl_addaminwarning" runat="server" />
                             <button type="button" class="close" data-dismiss="alert">
                                      <span>
                                          &times;
                                      </span>
                             </button>
                        </div>
                    </asp:Panel>      

                <div class="row" style="height: 7.3em;">
                    
                      <label class="col-md-2">Pick Client :</label>
                        <div class="col-md-4">
                             <asp:DropDownList ID="drpClientPersonTomeet" runat="server" DataSourceID="SqlDataSource1" AutoPostBack="true"
                                 DataTextField="name" DataValueField="name" class="rounded py-1 px-5 text-center" style="font-size:18px;"
                                 onmousedown="this.size=3;" onfocusout="this.size=2;"> 
                                 <asp:ListItem>SELECT</asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
                  <div class="row mb-4" style="height:70px">
                    <label class="col-md-2">Contact Name :</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtcontactpersonname" class="rounded py-1 px-3" placeholder="<--contact person-->" runat="server"></asp:TextBox><br />
                            
                        </div>
                      <asp:RequiredFieldValidator ID="Requiredcontactname" runat="server" ValidationGroup="CONTACT" ErrorMessage="Enter Contact Name" ControlToValidate="txtcontactpersonname" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                      </div>
                  <div class="row mb-4" style="height:70px">
                    <label class="col-md-2">Contact Email :</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtcontactpersonemail" class="rounded py-1 px-3" placeholder="<--contact email-->" runat="server"></asp:TextBox><br />
                            
                        </div>
                      <asp:RequiredFieldValidator ID="Requiredcontactemail" runat="server" ValidationGroup="CONTACT" ErrorMessage="Enter Contact Email" ControlToValidate="txtcontactpersonemail" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                      </div>
                  <div class="row mb-4" style="height:70px">
                     <label class="col-md-2">Contact Phone :</label>
                        <div class="col-md-4">
                            <asp:TextBox ID="txtcontactpersonphone" class="rounded py-1 px-3" placeholder="<--contact phone-->" runat="server"></asp:TextBox><br />
                           
                        </div>
                       <asp:RequiredFieldValidator ID="Requiredcontactphone" runat="server" ValidationGroup="CONTACT" ErrorMessage="Enter Contact Phone" ControlToValidate="txtcontactpersonphone" ForeColor="red" Display="Dynamic"></asp:RequiredFieldValidator>
                      </div>
                      <div class="card-footer">
                     <div class="offset-2">
                         <asp:Button ID="btncontactperson" runat="server" class="py-2" Text="ADD CONTACT" ValidationGroup="CONTACT" OnClick="btncontactperson_Click"
                             CssClass="btn" BackColor="#343A40" BorderStyle="None" ForeColor="White"/>
                         
                            
                     </div> 
                    </div>
                    </div>
                
            </asp:Panel>

                                                   
             </div>
             
        </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sekat %>" SelectCommand="SELECT [name] FROM [clients]"></asp:SqlDataSource>


</asp:Content>

