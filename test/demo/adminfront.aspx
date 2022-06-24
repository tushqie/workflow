<%@ Page Title="" Language="C#" MasterPageFile="~/demo/admincommonsections.master" AutoEventWireup="true" CodeFile="adminfront.aspx.cs" Inherits="demo_adminfront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headplaceholder" Runat="Server">   
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" Runat="Server">

    <div class="col-md-12">
        <div class="card">
           
            <div class="btn-group" style="background-color: black;">  
                <asp:Button ID="btn_paneladdadmin" runat="server" Text="SEARCH REPORTING"  style="background-color: #FF6500;padding-right: 20px;padding-left: 20px;border-radius:0px" CssClass="btn btn-info" BorderStyle="None" CausesValidation="False" />
            </div>
            <div class="card-body" style="height:800px">
                <div class="row" style="height:auto">
                    <div class="col-md-12 mb-3" id="search">

                            <asp:Panel ID="pnl_warning" runat="server" Visible="False">
                            <div class="card-footer">                           
                                <div class="alert alert-danger text-center">
                                   <asp:Label ID="lbl_warning" runat="server" />
                                     <button type="button" class="close" data-dismiss="alert">
                                          <span>
                                              &times;
                                          </span>
                                    </button>
                                </div>
                            </div>
                        </asp:Panel>

                          <asp:DropDownList ID="DropDownList1" runat="server" style="font-family:Ebrima;font-size:18px;color:#650909">
                               <asp:ListItem>fullname</asp:ListItem>
                               <asp:ListItem>client_task</asp:ListItem>
                               <asp:ListItem>client_amount</asp:ListItem>
                               <asp:ListItem>applied_date</asp:ListItem>
                              <asp:ListItem>client_name</asp:ListItem>
                               <asp:ListItem>approved_by</asp:ListItem>
                          </asp:DropDownList>

                       <asp:TextBox class="mt-1 mb-1 px-3 py-0 text-center" ID="txtsearch" style="font-family:Ebrima;font-size:18px" placeholder="<--Text to Search-->" runat="server"></asp:TextBox>
                   

                         <asp:Button ID="SearchGrid" CssClass="imole rounded px-2" BackColor="Black" BorderStyle="None" ForeColor="White" runat="server" Text="Search Grid"
                          OnClick="SearchGrid_Click" />
                    </div>
                    <div class="col-md-12">

                        <asp:Label ID="txttotalrec" runat="server" Text="" style="color:#FF6500;font-weight:bolder;"></asp:Label>

                       
                                   <asp:GridView ID="gdvAdmin" runat="server" CellPadding="2"  CellSpacing="0" ForeColor="#333333" GridLines="None" 
                                AutoGenerateColumns="false" ShowFooter="true" style="width:1000px;height:600px;overflow-y:scroll;" DataKeyNames="id" ShowHeaderWhenEmpty="true"
                                OnRowUpdating="gdvAdmin_RowUpdating" class="table table-responsive" OnRowCommand="gdvAdmin_RowCommand"
                                OnRowDataBound="gdvAdmin_RowDataBound" OnRowEditing="gdvAdmin_RowEditing" OnRowCancelingEdit="gdvAdmin_RowCancelingEdit">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#E3EAEB" />
                                <FooterStyle BackColor="#FF6500" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#FF6500" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <asp:Label id="lblid" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtid" runat="server" Text='<%# Eval("id") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtidf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FULLNAME">
                                        <ItemTemplate>
                                            <asp:Label id="lblfn" runat="server" Text='<%# Eval("fullname") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtfn" runat="server" Text='<%# Eval("fullname") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtfnf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CLIENT">
                                        <ItemTemplate>
                                            <asp:Label id="lblcn" runat="server" Text='<%# Eval("client_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtcn" runat="server" Text='<%# Eval("client_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtcnf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LOCATION">
                                        <ItemTemplate>
                                            <asp:Label id="lblcl" runat="server" Text='<%# Eval("client_location") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtcl" runat="server" Text='<%# Eval("client_location") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtclf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AMOUNT">
                                        <ItemTemplate>
                                            <asp:Label id="lblca" runat="server" Text='<%# Eval("client_amount") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtca" runat="server" Text='<%# Eval("client_amount") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtcaf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TASK">
                                        <ItemTemplate>
                                            <asp:Label id="lblct" runat="server" Text='<%# Eval("client_task") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtct" runat="server" Text='<%# Eval("client_task") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtctf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="APPLIED">
                                        <ItemTemplate>
                                            <asp:Label id="lblad" runat="server" Text='<%# Eval("applied_date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtad" runat="server" Text='<%# Eval("applied_date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtadf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="APPROVAL">
                                        <ItemTemplate>
                                            <asp:Label id="lblab" runat="server" Text='<%# Eval("approved_by") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtab" runat="server" Text='<%# Eval("approved_by") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtabf" runat="server" ></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="CHECKER">
                                        <ItemTemplate>
                                            <asp:ImageButton id="imgB" ImageUrl="~/assets/logo/delete.png" runat="server" 
                                             OnClientClick = "return confirm('Are you sure you want to delete this record?')"
                                              ToolTip="DELETE ROW RECORD" OnClick="imgB_Click"/>                        
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ICONS">
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/assets/logo/edit.png" runat="server" CommandName="Edit" ToolTip="Edit"/>
                                            <%--<asp:ImageButton ImageUrl="~/assets/logo/delete.png" runat="server" CommandName="Delete" ToolTip="Delete"/>--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                           <asp:ImageButton ImageUrl="~/assets/logo/update.png" runat="server" CommandName="Update" ToolTip="Update"/>
                                            <asp:ImageButton ImageUrl="~/assets/logo/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel"/>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <asp:ImageButton ImageUrl="~/assets/logo/add.png" runat="server" CommandName="AddNew" ToolTip="Add New"/>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                        </Columns>
                                </asp:GridView>
          
                    </div>
                    
                </div>
              </div>
        </div>
     </div>

</asp:Content>

