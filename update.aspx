<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <h2>Güncelle <small>Users</small></h2>
    <p></p>
    <div class="container-header">
        <div class="table">
            <div class="table-header">
                <div class="header__item"><a id="id" class="filter__link" href="#">User ID</a></div>
                <div class="header__item"><a id="l_name" class="filter__link filter__link--number" href="#">Login Name</a></div>
                <div class="header__item"><a id="pass" class="filter__link filter__link--number" href="#">Password</a><button>*</button></div>
                <div class="header__item"><a id="l_name1" class="filter__link filter__link--number" href="#">FIRST Name</a></div>
                <div class="header__item"><a id="l_name2" class="filter__link filter__link--number" href="#">Last Name</a></div>
                <div class="header__item"><a id="auth" class="filter__link filter__link--number" href="#">Authority Level</a></div>
                <div class="header__item"><a id="bday" class="filter__link filter__link--number" href="#">Birthday</a></div>
                <div class="header__item"><a id="salary" class="filter__link filter__link--number" href="#">Salary</a></div>
                <div class="header__item"><a id="action" class="filter__link filter__link--number" href="#">Action</a></div>
            </div>
        </div>
    </div>
    <div class="container">
        <asp:DataList ID="DataList2" runat="server" Width="1127px" AutoPostBack="true">
            <ItemTemplate>
                <div class="table">
                    <div class="table-content1">
                        <div class="table-row">
                            <div class="table-data">
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("User_ID") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("Login_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Password") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("First_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Last_name") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("Authority_Level") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Birthday", "{0:d}") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:Label ID="Label8" runat="server" Text='<%# Eval("Salary") %>'></asp:Label>
                            </div>
                            <div class="table-data">
                                <asp:LinkButton ID="LinkBtnUpdate" OnClick="LinkBtnUpdate_Click" OnCommand="LinkBtnUpdate_Command" runat="server" CommandArgument='<%# Eval("User_ID") %>' class="noselect"> <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="60" height="20px">
<path d="M 20 4 C 15.054688 4 11 8.054688 11 13 L 11 35.5625 L 5.71875 30.28125 L 4.28125 31.71875 L 11.28125 38.71875 L 12 39.40625 L 12.71875 38.71875 L 19.71875 31.71875 L 18.28125 30.28125 L 13 35.5625 L 13 13 C 13 9.144531 16.144531 6 20 6 L 31 6 L 31 4 Z M 38 10.59375 L 37.28125 11.28125 L 30.28125 18.28125 L 31.71875 19.71875 L 37 14.4375 L 37 37 C 37 40.855469 33.855469 44 30 44 L 19 44 L 19 46 L 30 46 C 34.945313 46 39 41.945313 39 37 L 39 14.4375 L 44.28125 19.71875 L 45.71875 18.28125 L 38.71875 11.28125 Z"></path>
</svg></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <div class="container-popup">
            <div id="update" class="modal" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h2>Güncelle</h2>
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblmsg" Text="" runat="server" />
                            <label>Login Name:</label>
                            <asp:TextBox ID="txtlogname" CssClass="form-control" placeholder="Login Name" runat="server" />
                            <label>Password:</label>
                            <asp:TextBox ID="txtpass" CssClass="form-control" placeholder="Password" runat="server" />
                            <label>First Name:</label>
                            <asp:TextBox ID="txtfname" CssClass="form-control" placeholder="First Name" runat="server" />
                            <label>Last Name:</label>
                            <asp:TextBox ID="txtlname" CssClass="form-control" placeholder="Last Name" runat="server" />
                            <label>Authority Level:</label>
                            <asp:TextBox ID="txtauth" CssClass="form-control" placeholder="Authority Level" runat="server" />
                            <label>Birthday:</label>
                            <asp:TextBox ID="txtbday" CssClass="form-control" placeholder="Birthday" runat="server" />
                            <label>Salary:</label>
                            <asp:TextBox ID="txtsalary" CssClass="form-control" placeholder="Salary" runat="server" />
                            <asp:HiddenField ID="hdid" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnupdate" CssClass="btn btn-primary" Text="Save" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    &nbsp;
    &nbsp;
    &nbsp;
</asp:Content>

