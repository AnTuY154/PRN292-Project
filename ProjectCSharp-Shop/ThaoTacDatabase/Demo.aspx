<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Common.Master" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="ProjectCSharp_Shop.ThaoTacDatabase.Demo" %>

<%@ Import Namespace="ProjectCSharp_Shop.DAO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%List<Account> listAccount = (List<Account>)Session["listAccount"]; %>
  
    <table border="1">
          <%foreach (var item in listAccount)
        {
    %>
       <tr>
           <td><%=item.Username %></td>
           <td><%=item.Password %></td>
           <td></td>
       </tr>
    <%} %>
    </table>
  
        
  
</asp:Content>
