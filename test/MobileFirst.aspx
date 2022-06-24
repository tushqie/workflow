<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MobileFirst.aspx.cs" Inherits="MobileFirst" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>        
    <link href="assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
     <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
   
      
    <link href="mobilefirst.css" rel="stylesheet" />
    
    <style type="text/css">

        :root{
             --orange: #FF6500;
        }
       
       
    </style>
</head>
<body>
    <%--<div id="splash">
            <img src="assets/logo/sekatlogo.png" />
        </div>--%>
    <form id="form1" runat="server">
       
    <div>
         
        <div class="content">
            <header class="app-header">              
                <div class="container">
                    
                    <div class="fixed-top d-flex justify-content-around" style="background-color:#FF6500;height: 9em;">
                      
                       <div id="logo">
                        
                               <img class="logo pt-2" src="assets/logo/sekatlogo.png" />  
                         
                       </div>
                         
                        <div style="color:white;padding-top: 3em;" id="title">
                            <h3 id="b"><b>STAFF MOVEMENT AND SUPPORT WORKFLOW</b></h3>                          
                        </div> 
                       <div class="text-light text-center imole" id="welcome"> 
                                
                            <i class="fa fa-user-circle fa-5x"></i>
                            <h4 class="">Welcome</h4>
                            <asp:Label ID="lbl_loggedInUser" runat="server"
                               class="px-3 py-2 p-md-1 alert-success p-0 rounded" Text=""></asp:Label>
                                
                       </div>
                                                                      
                    </div>

                </div>
            </header>

            <div class="subheader" style="margin-top:110px;">  <%-- ;margin-bottom:0px;--%>
                            
                <div ID="span" runat="server" ></div>

                    <h5><asp:LinkButton ID="link_loginout" runat="server" style="color: var(--orange); padding-right: 2.1rem;"
                      CssClass="nav-link" OnClick="link_loginout_Click">Log out</asp:LinkButton></h5>
              
            </div>

                    <div class="jumbotron mx-5 mt-0 py-3 mb-0 pb-0 pr-0 pl-4" id="meet" style="background-color:#FF6500;border-radius:0px">              <%--start border line--%>

                            <div class="row d-flex justify-content-around" style="height: 90px">
                               


                                    <div class="col-4 pt-0" style="height:80px;padding-left: 40px">
                                        <div>
                                            <h6 class="text-light"><strong> Client Name :</strong></h6>

                                        </div>                                  
                                              <div class="col-8-sm d-flex flex-column align-self-stretch justify-content-center">                        
                                                  <asp:DropDownList ID="drpclientname" class="rounded border-0 px-4 pb-1 text-center pt-2" style="font-size:18px;color:orangered" onmousedown="this.size=3;" onfocusout="this.size=2;"
                                                       AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpclientname_SelectedIndexChanged"></asp:DropDownList>
                                              </div>
                                    </div>
                               
                               
                                     <div class="col-4 pt-0 px-0" style="height:80px;">
                    
                                                    <h6 class="text-light"><strong>Fee :</strong></h6>
                                                    <div class="form-group d-flex">
                                                        <div class="input-group-prepend" style="background-color: white;">
                                                            <div class="input-group-text rounded-0" style="background-color: #41dfec;color:#FF6500;font-weight:bolder;">&#8358</div>
                                                        </div>
                                                                                                 
                                                            <asp:TextBox ID="txtclientfee" class="form-control px-0 pb-1 pt-1 rounded-0 pl-1" style="                                                                    font-size: 18px;
                                                                    color:orangered;background-color: white;" runat="server" ReadOnly="True"></asp:TextBox>                                                    
                                                       
                                                        <div class="input-group-append d-flex d-sm-inline" style="background-color: white;">
                                                            <div class="input-group-text" style="background-color: #41dfec;color:#FF6500;font-weight:bolder;">.00</div>
                                                        </div>
                                                     </div>
                                     </div>
                               
                              
                                    <div class="col-4 pt-0" style="                                            height: 80px;
                                    ">
                                                <h6 class="text-light"><strong>Client Address :</strong></h6>
                                                <div class="col-8-lg mr-4 d-flex flex-column align-self-stretch justify-content-center">
                                                    <asp:TextBox TextMode="multiline" Columns="5" Rows="1" ID="txtaddress"
                                                        class="rounded border-0 px-0 text-center pb-1 pt-1" 
                                                        style="color:orangered" runat="server"></asp:TextBox>
                                                </div>
                                    </div>
                                
                              
                            </div>

                            
                            
                 <hr style="background-color:white" class="ml-4 mr-5 mt-0"/>   <%--hr line--%>


                                <div class="row" style="height:90px">
            
                     
                                                <div class="col-4">
                   
                                                    <strong><asp:Label ID="lblcp" class="ml-4 text-light" runat="server" Text="Contact Person :"></asp:Label></strong>
                                                                <div class="col-8-sm ml-4 mt-2"> 
                                                                     <asp:DropDownList ID="drpcontactperson" AutoPostBack="true" style="font-size:18px;color:orangered" runat="server" class="rounded border-0 text-center pb-2 pt-0 px-2" OnSelectedIndexChanged="drpcontactperson_SelectedIndexChanged">
                                                                     </asp:DropDownList>
                                    
                                                                </div>
                                                </div>
                                                <div class="col-4">
                  
                                                     <h6><strong><asp:Label ID="lblph" class="col-form-label mt-0 pt-1 text-light" runat="server" Text="Phone:"></asp:Label></strong></h6>
                                                          <div class="col-8-sm">
                                                               <strong><asp:Label ID="lblperson" class="badge-light px-2 pt-1 pb-2 ml-0 rounded px-5" style="color:orangered" runat="server" Visible="False"></asp:Label></strong>                                   
                                                          </div>
                                                </div>
                                                <div class="col-4">
                 
                                                    <h6><strong><asp:Label ID="lble" class="col-form-label mt-0 pt-1 text-light" runat="server" Text="Email:"></asp:Label></strong></h6>
                                                        <div class="col-8-lg">
                                                                <strong><asp:Label ID="lblemail" class="badge-light px-2 pt-1 pb-2 ml-0 rounded px-3" style="color:orangered" runat="server" Visible="False"></asp:Label></strong>
                                                        </div>
                                                </div>
    
                                </div>


                             <hr style="background-color:white" class="ml-4 mr-5 mt-2"/>


                                <div class="row" style="height:60px">
                                               

                                                    <div class="col-4 mt-0">                                                 
                                                        <div class="ml-4 mt-0" runat="server">                                                                          
                                                            <asp:DropDownList ID="drptask" class="rounded border-0 py-2 pr-1 pl-4 text-center" style="font-size:18px;color:orangered" runat="server" onmousedown="this.size=3;" onfocusout="this.size=1;"> 
                                                                          <asp:ListItem><--Select Task--></asp:ListItem>
                                                                          <asp:ListItem>Training</asp:ListItem>
                                                                          <asp:ListItem>Support</asp:ListItem>
                                                                          <asp:ListItem>Meeting</asp:ListItem>
                                                                          <asp:ListItem>Data Implementation</asp:ListItem>
                                                            </asp:DropDownList>
                                                            
                                                        </div>
                                                    </div>
                                                    <div class="col-4 pl-0 mt-0">
                                                        <div class="ml-3 mt-0" runat="server"> 
                                                            <asp:TextBox ID="txtdate" class="px-2 pt-1 pb-2 ml-0 rounded border-0" style="font-size:18px;color:orangered" runat="server" placeholder="<--Click Here for Date-->"></asp:TextBox>
                                  
                                                        </div>
                                                    </div>
                                                    <div class="col-4 pl-0 mt-0">
                                                        <div class="ml-3 mt-0" runat="server">                                                              
                                                            <asp:Button ID="Button1" runat="server" class="btn btn-primary rounded border-0 text-center pb-2 pt-0" Text="Submit" OnClick="Button1_Click" /> 
                                                        </div>
                                                    </div>
                                </div>

                        <hr style="background-color:white" class="ml-4 mr-5 mt-0"/>

                <div class="d-flex justify-content-around imole">
                
                   
                         <div class="">
                             <asp:TextBox ID="txtSearch" class="text-center" runat="server" style="color:#FF6500;" placeholder="<--Amount-->"/>   
                             <asp:TextBox ID="txtStaff" runat="server" class="text-center" style="color:#FF6500;" placeholder="<--Staff Name-->" /> 
                        </div>
                        
                         
                        <div class="">
                           <asp:TextBox ID="txtClient" runat="server" class="text-center" style="color:#FF6500;" placeholder="<--Client-->" />
                           <asp:TextBox ID="txtApprovedby" runat="server" class="text-center" style="color:#FF6500;" placeholder="<--Approved by-->" /> 
                        </div>
                        
                       
                       <div class="">
                            <asp:TextBox ID="txtdateapplied" class="text-center" runat="server" style="color:#FF6500;" placeholder="<--Date-->" />  
                             <asp:TextBox ID="txttask" runat="server" class="text-center" style="color:#FF6500;" placeholder="<--Task-->" />                                   
                       </div>

                      <div class="">
                            <asp:Button Text="Search" ID="btnSearch" Autopostback="false" runat="server" 
                                class="btn btn-primary py-0" OnClick="Search"/> 
                            </div>
                    
                </div>
                       
                     
                        </div>                                                                               <%--end of border--%>



             <div class="sticky-footer mx-5">
                  <div class="jumbotron mx-0 mt-0 text-light px-3 py-2" style="background-color:#FF6500;border-radius:0px">
                      
                                                <asp:Panel ID="pnl_warning" runat="server" Visible="False">
                                                        <div class="alert alert-danger text-center py-5">
                                                            <asp:Label ID="lbl_warning" runat="server" Text=""></asp:Label>
                                                             <button type="button" class="close" data-dismiss="alert">
                                                                          <span>
                                                                              &times;
                                                                          </span>
                                                             </button>
                                                         </div>
                                                </asp:Panel>

                      <div class="d-flex justify-content-around">
                      <div class="d-flex flex-column justify-content-around" id="shrinktable">                         
                        
                          <asp:Label ID="txttotalrec" runat="server" Text="" style="color:#fbfbfb;font-weight:bolder;"></asp:Label>
                        
                          <table class="table mr-2 mb-2"
                                                      style="background-color: #DEBA84;
                                                         border-color: #DEBA84;
                                                         border-width: 1px;
                                                         border-style: None;
                                                         border-collapse: collapse;
                                                         width:1300px;
                                                         height: 50px;
                                                         text-align: center">
		                                            <tr class="d-flex align-items-center justify-content-around"
                                                        style="color:White;background-color:#A55129;font-weight:bold;">
			                                            <th class="border-0 myH">ID</th>
                                                        <th class="border-0">staff</th>
                                                        <th class="border-0">client_name</th>
                                                        <th class="border-0">location</th>
                                                        <th class="border-0">amount</th>
                                                        <th class="border-0">task</th>
                                                        <th class="border-0">applied_on</th>
                                                        <th class="border-0">approval</th>
                                                        <th class="border-0">icon</th>         
		                                            </tr>
                        </table>

               
            <asp:GridView ID="gdvSearch"  runat ="server"  AutoGenerateColumns="False" ShowHeader = "false" class="table table-responsive"
                                      style="width:1300px;text-align:center;overflow-y:scroll;" DataKeyNames="id"
                                    OnRowDataBound="gdvSearch_RowDataBound" BorderColor="#DEBA84"  BorderStyle="None"
                                      BorderWidth="1px"  onmousedown="this.size=3;" onfocusout="this.size=1;">
                                    <Columns>                                                               
                                   
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id" ItemStyle-Width = "150px" />
                                        <asp:BoundField DataField="fullname" SortExpression="fullname" ItemStyle-Width = "150px" />
                                        <asp:BoundField DataField="client_name" ItemStyle-Width = "300px"/>
                                        <asp:BoundField DataField="client_location" ItemStyle-Width = "150px" />
                                        <asp:BoundField DataField="client_amount" ItemStyle-Width = "150px"/>
                                        <asp:BoundField DataField="client_task" ItemStyle-Width = "150px"/>
                                         <asp:BoundField DataField="applied_date" SortExpression="applied_date" ItemStyle-Width = "150px"/>
                                        <asp:BoundField DataField="approved_by" SortExpression="approved_by" ItemStyle-Width = "150px"/>
                                       <asp:TemplateField>
                                           <ItemTemplate>
                                                  <asp:ImageButton id="imgB" runat="server" ImageUrl="~/assets/logo/delete.png" 
                                                OnClientClick = "return confirm('Are you sure you want to delete this record?')"
                                                   OnClick="imgB_Click"   ToolTip="delete this pending request"/>
                                           </ItemTemplate>
                                       </asp:TemplateField>

                               
                                    </Columns>
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" CssClass="Center" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                 </asp:GridView>
             
                      </div>
                          </div>
                      </div>
                   </div>
             </div>

        </div>   <%--content div--%>

         <footer class="sticky-footer mx-5" style="height:100px">
            
               <div class="jumbotron mx-0 mt-2 text-light pt-5" style="                       background-color: #FF6500;
                       margin-top: 20px;
                       height: 5px
               "> 
                <div class="text-center">Copyright &copy; SEKAT GROUP <span class="badge-light rounded px-1 py-1">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
                </div>
                
            </div>
        </footer>

    </form>
   
    <!-- Bootstrap core JavaScript-->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/bootstrap.bundle.min.js"></script>
     <script src="assets/js/bootstrap.min.js"></script>
        <script src="../assets/js/custom.js"></script>


    <script type="text/javascript" src="assets/js/jquery-1.8.3.min.js"></script>  <%--  datepicker 1  --%> 
     <link href="assets/css/jquery-ui.css" rel="stylesheet" />  <%--   datepicker 2--%>
    <script src="assets/js/jquery-ui.js"></script>        <%--   datepicker 3--%>
   
    

    <script type="text/javascript">

            setTimeout(() => {
                document.getElementById('splash').classList.add('fade');
            }, 2000)

        $(function () {
            $('[id*=txtdateapplied]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yy",
                language: "tr"
            });
        });


        $(function () {
            $('[id*=txtdate]').datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd/mm/yy",
                language: "tr"
            });
        });

        //function ShowModal(title, body)
        //{
        //    //console.log("document imoleayo hi i am here snow");
        //    $("div.modal-title").html(title);
        //    $("div.modal-body").html(body);
        //    $("div").modal("show");
        //}

        $(function () {
            $("#btnShowLogin").click(function () {
                $('#LoginModal').modal('show');
            });
        });
        
    </script>
     

</body>
</html>
