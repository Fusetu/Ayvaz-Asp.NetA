<%@ Page Title="Ayvaz" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="delete.aspx.cs" Inherits="deldata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <h2>Güncelle <small>Users</small></h2>
    <p></p>
    <div class="container-header">
        <div class="table">
            <div class="table-header">
                <div class="header__item"><a id="id" class="filter__link" href="#">User ID</a></div>
                <div class="header__item"><a id="l_name" class="filter__link filter__link--number" href="#">Login Name</a></div>
                <div class="header__item"><a id="pass" class="filter__link filter__link--number" href="#">Password</a></div>
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
        <asp:DataList ID="DataList2" runat="server" Style="margin-left: 0px" Width="1127px" AutoPostBack="true">
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
                                <asp:LinkButton ID="LinkBtnDelete" OnClientClick="return window.confirm('Bu veriyi silmek istediğinize emin misiniz?');" runat="server" CommandArgument='<%# Eval("User_ID") %>' class="noselect"> <svg xmlns="http://www.w3.org/2000/svg" height="1.5em" viewBox="0 0 512 512"><path d="M256 512A256 256 0 1 0 256 0a256 256 0 1 0 0 512zM184 232H328c13.3 0 24 10.7 24 24s-10.7 24-24 24H184c-13.3 0-24-10.7-24-24s10.7-24 24-24z"/></svg></asp:LinkButton>
                                <asp:LinkButton ID="LinkBtnUpdate" OnClick="LinkBtnUpdate_Click" OnCommand="LinkBtnUpdate_Command" runat="server" CommandArgument='<%# Eval("User_ID") %>' class="noselect"> <svg xmlns="http://www.w3.org/2000/svg" height="1.5em" viewBox="0 0 512 512"><path d="M174.7 45.1C192.2 17 223 0 256 0s63.8 17 81.3 45.1l38.6 61.7 27-15.6c8.4-4.9 18.9-4.2 26.6 1.7s11.1 15.9 8.6 25.3l-23.4 87.4c-3.4 12.8-16.6 20.4-29.4 17l-87.4-23.4c-9.4-2.5-16.3-10.4-17.6-20s3.4-19.1 11.8-23.9l28.4-16.4L283 79c-5.8-9.3-16-15-27-15s-21.2 5.7-27 15l-17.5 28c-9.2 14.8-28.6 19.5-43.6 10.5c-15.3-9.2-20.2-29.2-10.7-44.4l17.5-28zM429.5 251.9c15-9 34.4-4.3 43.6 10.5l24.4 39.1c9.4 15.1 14.4 32.4 14.6 50.2c.3 53.1-42.7 96.4-95.8 96.4L320 448v32c0 9.7-5.8 18.5-14.8 22.2s-19.3 1.7-26.2-5.2l-64-64c-9.4-9.4-9.4-24.6 0-33.9l64-64c6.9-6.9 17.2-8.9 26.2-5.2s14.8 12.5 14.8 22.2v32l96.2 0c17.6 0 31.9-14.4 31.8-32c0-5.9-1.7-11.7-4.8-16.7l-24.4-39.1c-9.5-15.2-4.7-35.2 10.7-44.4zm-364.6-31L36 204.2c-8.4-4.9-13.1-14.3-11.8-23.9s8.2-17.5 17.6-20l87.4-23.4c12.8-3.4 26 4.2 29.4 17L182 241.2c2.5 9.4-.9 19.3-8.6 25.3s-18.2 6.6-26.6 1.7l-26.5-15.3L68.8 335.3c-3.1 5-4.8 10.8-4.8 16.7c-.1 17.6 14.2 32 31.8 32l32.2 0c17.7 0 32 14.3 32 32s-14.3 32-32 32l-32.2 0C42.7 448-.3 404.8 0 351.6c.1-17.8 5.1-35.1 14.6-50.2l50.3-80.5z"/></svg></asp:LinkButton>
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
                            <label>Authority Level: (1 - 2)</label>
                            <asp:TextBox ID="txtauth" CssClass="form-control" placeholder="Authority Level" runat="server" />
                            <label>Birthday:</label>
                            <asp:TextBox ID="txtbday" TextMode="Date" CssClass="form-control" placeholder="Birthday" runat="server" />
                            <label>Salary:</label>
                            <asp:TextBox ID="txtsalary" CssClass="form-control" placeholder="Salary" runat="server" />
                            <asp:HiddenField ID="hdid" runat="server" />
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnupdate" CssClass="btn btn-primary" OnClick="btnupdate_Click" Text="Save" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="paging">
        <div class="page-labels" runat="server">
            <asp:Label ID="lblCurrentPage" runat="server" Text="Label"></asp:Label>
            <asp:Label ID="pageCount" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>
        <div class="page-buttons" runat="server">
            <asp:Button ID="btnFirst" class="page-button" runat="server" Font-Bold="true" Text="First" OnClick="btnFirst_Click" />
            <asp:Button ID="btnPre" class="page-button" runat="server" Font-Bold="true" Text="Previous" OnClick="btnPre_Click" />
            <asp:Button ID="btnNext" class="page-button" runat="server" Font-Bold="true" Text="Next" OnClick="btnNext_Click" />
            <asp:Button ID="btnLast" class="page-button" runat="server" Font-Bold="true" Text="Last" OnClick="btnLast_Click" />
        </div>
    </div>

    &nbsp;
    &nbsp;
    &nbsp;
</asp:Content>

