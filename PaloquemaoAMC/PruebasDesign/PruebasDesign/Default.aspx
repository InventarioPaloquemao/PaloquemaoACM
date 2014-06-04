<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PaloquemaoACM.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Default" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <!-- Incio -->
    <div id="inicio" class="content">


        <!--Boton de busqueda-->
        <div class="sb-search">
            <form>
                <%--<input class="sb-search-input" placeholder="Ingrese su busqueda por favor..." 
                    type="text" value="" name="search" id="txbBuscar">--%>
                <asp:TextBox ID="txbBuscar" runat="server" CssClass="sb-search-input"></asp:TextBox>
                <%--<input class="sb-search-submit" type="submit" value="" runat="server" onclick="">--%>
                <asp:Button ID="btnBuscar" runat="server" CssClass="sb-search-submit" OnClick="btnBuscar_Click" />
                <span class="sb-icon-search"></span>
            </form>
        </div>
        <!--/Boton de busqueda-->


        <asp:Table ID="tableNav" runat="server"></asp:Table>

        <asp:GridView runat="server" ID="gvCategorias" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="grid-result" OnSelectedIndexChanged="gvCategorias_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="Actualizar existencias "/>
            </Columns>
        </asp:GridView>

        <%--Inicio--%>
    </div>
    <!-- /Inicio -->

    <!-- Registro producto -->
    <div id="registroProducto" class="panel">
        <div class="content">

            <p>Nuevo producto</p>


            <table style="width: 100%;" runat="server" id="tablaGeneral" class="table table-hover">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCodigo" runat="server" Text="Codigo producto"></asp:Label>

                    </td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txbCodigo" runat="server"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblNombreProd" runat="server" Text="Nombre producto"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txbNombreProd" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombreProd" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txbNombreProd"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCantixCaja" runat="server" Text="Unidades por caja"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txbCantixCaja" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCantixCaja" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txbCantixCaja"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblTotalUnidades" runat="server" Text="Total unidades"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txbTotalUnidades" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTotalUnidades" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txbTotalUnidades"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblPrecioProveedor" runat="server" Text="Precio proveedor"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:TextBox ID="txbPrecioProveedor" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrecioProveedor" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txbPrecioProveedor"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblProveedor" runat="server" Text="Proveedor"></asp:Label></td>

                    <td class="auto-style1">
                        <asp:DropDownList ID="ddlProveedor" runat="server"></asp:DropDownList>
                        </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnCrearProducto" runat="server" Text="Nuevo Producto" OnClick="btnCrearProducto_Click" CssClass="btn btn-warning" />
                    </td>
                    <td class="auto-style1">
                        <asp:Label ID="lblErrorProd" runat="server"></asp:Label>
                    </td>
                </tr>

            </table>



            <!--/Formulario de ingreso de nuevo producto-->


        </div>
    </div>
    <!-- /Registro producto -->

    <!-- Pedidos -->
    <div id="pedidos" class="panel">
        <div class="content">

            <p>It is a paradisematic country, in which roasted parts of sentences fly into your mouth.</p>
            <p>Even the all-powerful Pointing has no control about the blind texts it is an almost unorthographic life One day however a small line of blind text by the name of Lorem Ipsum decided to leave for the far World of Grammar.</p>
            <p>The Big Oxmox advised her not to do so, because there were thousands of bad Commas, wild Question Marks and devious Semikoli, but the Little Blind Text didn’t listen.</p>
            <p>She packed her seven versalia, put her initial into the belt and made herself on the way.</p>
        </div>
    </div>
    <!-- /Pedidos -->


    <!-- Categorias -->

    <div id="categorias" class="panel">
        <div class="content">

            <!-- Divs Vivos -->
            <div class="main">

                <div class="view view-tenth">
                    <img src="imagenes/desechables1.jpg" />
                    <div class="mask">
                        <h2>Hover Style #10</h2>
                        <p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.</p>
                        <a href="#" class="info">Read More</a>
                    </div>
                </div>
                <div class="view view-tenth">
                    <img src="imagenes/licores1.jpg" />
                    <div class="mask">
                        <h2>Licores</h2>
                        <ul>
                            <li><a href="#">Licores</a></li>
                            <li><a href="#">Licores</a></li>
                            <li><a href="#">Licores</a></li>
                            <li><a href="#">Licores</a></li>
                        </ul>
                    </div>
                </div>
                <div class="view view-tenth">
                    <img src="imagenes/aceite1.jpg" />
                    <div class="mask">
                        <h2>Hover Style #10</h2>
                        <p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.</p>
                        <a href="#" class="info">Read More</a>
                    </div>
                </div>
                <div class="view view-tenth">
                    <img src="imagenes/enlatados1.jpg" />
                    <div class="mask">
                        <h2>Hover Style #10</h2>
                        <p>A wonderful serenity has taken possession of my entire soul, like these sweet mornings of spring which I enjoy with my whole heart.</p>
                        <a href="#" class="info">Read More</a>
                    </div>
                </div>

            </div>
            <!-- /Divs Vivos -->
        </div>
    </div>
    <!-- /Categorias -->

    <!-- Actualizar Existencias -->

    <div id="regProducto" class="panel">
        <div class="content">
            <h1>Actualizar Existencias</h1>
        </div>
    </div>
    <!-- /Actualizar existencias -->

    <!-- Contacto -->
    <div id="contact" class="panel">
        <div class="content">

            <p>When she reached the first hills of the Italic Mountains, she had a last view back on the skyline of her hometown Bookmarksgrove, the headline of Alphabet Village and the subline of her own road, the Line Lane.</p>
            <p>Pityful a rethoric question ran over her cheek, then she continued her way. On her way she met a copy.</p>
            <form id="form">
                <p>
                    <label>Your Name</label><input type="text" />
                </p>
                <p>
                    <label>Your Email</label><input type="text" />
                </p>
                <p>
                    <label>Your Message</label><textarea></textarea>
                </p>
            </form>
        </div>
    </div>
    <!-- /Contacto -->

    <script src="Scripts/Default.js" type="text/javascript"></script>
</asp:Content>
