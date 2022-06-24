<%@ Page Title="" Language="C#" MasterPageFile="~/demo/admincommonsections.master" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="admin_AddAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

     <div class="col-md-12">
        <div class="card">
            <div class="btn-group bg-dark">
                <asp:Button ID="btn_paneladdadmin" runat="server" Text="Add Role" style="background-color: #FF6500;" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" BackColor="#343A40" />
            </div>
            <div class="card-body">

                     <asp:Panel ID="panel_resetpass_warning" runat="server" Visible="false">             
                              <div class="alert alert-danger text-center">
                                  <button type="button" class="close" data-dismiss="alert">
                                      <span>
                                          &times;
                                      </span>
                                  </button>
                                <asp:Label ID="lbl_resetpasswarning" runat="server" />
                              </div>
                         </asp:Panel>
                <div class="row" style="height: 10rem;">
                    <div class="col-md-2">
                         <asp:DropDownList ID="drprolename" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="drprolename_SelectedIndexChanged">
                                <asp:ListItem>user</asp:ListItem>
                                <asp:ListItem>admin</asp:ListItem>
                                
                            </asp:DropDownList>
                    </div>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtrole" runat="server" class="form-control pl-2" Text="user"></asp:TextBox>
                    </div>
                     <div class="col-md-2">
                        <asp:Button ID="btnaddrole" runat="server" Text="CREATE ROLE" BackColor="#343A40" CssClass="btn" ForeColor="White" OnClick="btnaddrole_Click" />
                    </div>
                </div>
              </div>
              <div class="btn-group bg-dark">
                    <asp:Button ID="Button1" runat="server" Text="Change User Role" CssClass="btn btn-info" 
                        BorderStyle="None" style="background-color: #FF6500;" CausesValidation="False" BackColor="#343A40" />
              </div>
   
             <div class="card-body">
                <div class="row" style="height: 10rem;">
                    <div class="col-md-2">
                            <asp:DropDownList ID="drpAddUserPrivilege" runat="server" CssClass="form-control">
                                                <asp:ListItem>user</asp:ListItem>
                                                <asp:ListItem>admin</asp:ListItem>
                                                
                            </asp:DropDownList>
                    </div>
                    <div class="col-md-10">
                         <asp:DropDownList ID="drpSelectUserFromDB" runat="server" class="form-control pl-2"
                         DataSourceID="SqlDataSource1" DataTextField="admin_name" DataValueField="admin_name">                                                                           
                         </asp:DropDownList>
                    </div>
                     <div class="col-md-2">
                       <asp:Button ID="btnAddUser" runat="server" BackColor="#343A40" CssClass="btn" ForeColor="White" Text="ADD USER TO ROLE" OnClick="btnAddUser_Click" />
                    </div>
                </div>
              </div>     
                 <div class="card-footer">
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sekat %>" 
                    SelectCommand="SELECT [admin_name] FROM [admin]"></asp:SqlDataSource>
                   
                 </div>
                </div>
            </div>                                
 

</asp:Content>

