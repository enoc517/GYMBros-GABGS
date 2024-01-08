using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMBros_GABGS.Data.Migrations
{
    /// <inheritdoc />
    public partial class gym : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actividades",
                columns: table => new
                {
                    IDActividades = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividades", x => x.IDActividades);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaMembresia",
                columns: table => new
                {
                    IDCategoriaMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMembresia", x => x.IDCategoriaMembresia);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaProducto",
                columns: table => new
                {
                    IDCategoriaProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaProducto", x => x.IDCategoriaProducto);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IDCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Dirrecion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    EstadoCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SesionesRayosUVA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IDCliente);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFactura",
                columns: table => new
                {
                    ID_DetalleFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioUnidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFactura", x => x.ID_DetalleFactura);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IDProvedores = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IDProvedores);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    IDPuesto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagoHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoriaPuesto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.IDPuesto);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    IDSala = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateOnly>(type: "date", nullable: false),
                    Cupo = table.Column<int>(type: "int", nullable: false),
                    Descripción = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.IDSala);
                });

            migrationBuilder.CreateTable(
                name: "ClienteMembresia",
                columns: table => new
                {
                    IDClienteMembresia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCategoraMembresia = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    FechaProxRenovacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteMembresia", x => x.IDClienteMembresia);
                    table.ForeignKey(
                        name: "FK_ClienteMembresia_CategoriaMembresia",
                        column: x => x.IDCategoraMembresia,
                        principalTable: "CategoriaMembresia",
                        principalColumn: "IDCategoriaMembresia");
                    table.ForeignKey(
                        name: "FK_ClienteMembresia_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                });

            migrationBuilder.CreateTable(
                name: "Martricula",
                columns: table => new
                {
                    IDMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDClase = table.Column<int>(type: "int", nullable: false),
                    IDCliente = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Martricula", x => x.IDMatricula);
                    table.ForeignKey(
                        name: "FK_Martricula_Cliente",
                        column: x => x.IDCliente,
                        principalTable: "Cliente",
                        principalColumn: "IDCliente");
                });

            migrationBuilder.CreateTable(
                name: "ProductosVenta",
                columns: table => new
                {
                    IDProductos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProvedores = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IDCategoriaProducto = table.Column<int>(type: "int", nullable: false),
                    FechaCaducidad = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosVenta", x => x.IDProductos);
                    table.ForeignKey(
                        name: "FK_ProductosVenta_CategoriaProducto",
                        column: x => x.IDCategoriaProducto,
                        principalTable: "CategoriaProducto",
                        principalColumn: "IDCategoriaProducto");
                    table.ForeignKey(
                        name: "FK_ProductosVenta_Proveedores",
                        column: x => x.IDProvedores,
                        principalTable: "Proveedores",
                        principalColumn: "IDProvedores");
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    IDEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDPuesto = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Dirreccion = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    FechaContratacion = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: false),
                    CategoriaProfesional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumSeguridadSocial = table.Column<int>(type: "int", nullable: false),
                    CuentaBancaria = table.Column<int>(type: "int", nullable: false),
                    RetencionCCSS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.IDEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleados_Puesto",
                        column: x => x.IDPuesto,
                        principalTable: "Puesto",
                        principalColumn: "IDPuesto");
                });

            migrationBuilder.CreateTable(
                name: "FacturaCliente",
                columns: table => new
                {
                    IDFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDClienteMembresia = table.Column<int>(type: "int", nullable: false),
                    FechaEmicion = table.Column<DateOnly>(type: "date", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCliente", x => x.IDFactura);
                    table.ForeignKey(
                        name: "FK_FacturaCliente_ClienteMembresia",
                        column: x => x.IDClienteMembresia,
                        principalTable: "ClienteMembresia",
                        principalColumn: "IDClienteMembresia");
                });

            migrationBuilder.CreateTable(
                name: "SesionesUV",
                columns: table => new
                {
                    IDSesiones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDClienteMembresia = table.Column<int>(type: "int", nullable: false),
                    CantidadSesiones = table.Column<int>(type: "int", nullable: false),
                    FechaSesion = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraSesion = table.Column<TimeOnly>(type: "time", nullable: false),
                    Disponibles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionesUV", x => x.IDSesiones);
                    table.ForeignKey(
                        name: "FK_SesionesUV_ClienteMembresia",
                        column: x => x.IDClienteMembresia,
                        principalTable: "ClienteMembresia",
                        principalColumn: "IDClienteMembresia");
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    IDClase = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDMatricula = table.Column<int>(type: "int", nullable: false),
                    IDActividad = table.Column<int>(type: "int", nullable: false),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    IDSala = table.Column<int>(type: "int", nullable: false),
                    FechaClase = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraInicio = table.Column<TimeOnly>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeOnly>(type: "time", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.IDClase);
                    table.ForeignKey(
                        name: "FK_Clases_Actividades",
                        column: x => x.IDActividad,
                        principalTable: "Actividades",
                        principalColumn: "IDActividades");
                    table.ForeignKey(
                        name: "FK_Clases_Empleados",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IDEmpleado");
                    table.ForeignKey(
                        name: "FK_Clases_Martricula",
                        column: x => x.IDMatricula,
                        principalTable: "Martricula",
                        principalColumn: "IDMatricula");
                    table.ForeignKey(
                        name: "FK_Clases_Sala",
                        column: x => x.IDSala,
                        principalTable: "Sala",
                        principalColumn: "IDSala");
                });

            migrationBuilder.CreateTable(
                name: "FacturaPedidos",
                columns: table => new
                {
                    IDFacturaPedidos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_DetalleFactura = table.Column<int>(type: "int", nullable: false),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaPedido = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaRecibido = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaPedidos", x => x.IDFacturaPedidos);
                    table.ForeignKey(
                        name: "FK_FacturaPedidos_DetalleFactura",
                        column: x => x.ID_DetalleFactura,
                        principalTable: "DetalleFactura",
                        principalColumn: "ID_DetalleFactura");
                    table.ForeignKey(
                        name: "FK_FacturaPedidos_Empleados",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IDEmpleado");
                });

            migrationBuilder.CreateTable(
                name: "Jornadas",
                columns: table => new
                {
                    IDJornadas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaFin = table.Column<DateOnly>(type: "date", nullable: false),
                    HorasTrabajadas = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornadas", x => x.IDJornadas);
                    table.ForeignKey(
                        name: "FK_Jornadas_Empleados",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IDEmpleado");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IDPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEmpleado = table.Column<int>(type: "int", nullable: false),
                    IDProvedores = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FechaCompra = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaRecibido = table.Column<DateOnly>(type: "date", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IDPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Empleados",
                        column: x => x.IDEmpleado,
                        principalTable: "Empleados",
                        principalColumn: "IDEmpleado");
                    table.ForeignKey(
                        name: "FK_Pedidos_Proveedores",
                        column: x => x.IDProvedores,
                        principalTable: "Proveedores",
                        principalColumn: "IDProvedores");
                });

            migrationBuilder.CreateTable(
                name: "GeneracionPagos",
                columns: table => new
                {
                    IDGeneracionPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDJornadas = table.Column<int>(type: "int", nullable: false),
                    DescripcionPago = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalarioBruto = table.Column<double>(type: "float", nullable: false),
                    EstadoDelPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Feriados = table.Column<int>(type: "int", nullable: false),
                    HorasExtras = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneracionPagos", x => x.IDGeneracionPago);
                    table.ForeignKey(
                        name: "FK_GeneracionPagos_Jornadas",
                        column: x => x.IDJornadas,
                        principalTable: "Jornadas",
                        principalColumn: "IDJornadas");
                });

            migrationBuilder.CreateTable(
                name: "HistortialPagos",
                columns: table => new
                {
                    IDHistorialPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDGeneracionPagos = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateOnly>(type: "date", nullable: false),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistortialPagos", x => x.IDHistorialPago);
                    table.ForeignKey(
                        name: "FK_HistortialPagos_GeneracionPagos",
                        column: x => x.IDGeneracionPagos,
                        principalTable: "GeneracionPagos",
                        principalColumn: "IDGeneracionPago");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IDActividad",
                table: "Clases",
                column: "IDActividad");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IDEmpleado",
                table: "Clases",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IDMatricula",
                table: "Clases",
                column: "IDMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Clases_IDSala",
                table: "Clases",
                column: "IDSala");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresia_IDCategoraMembresia",
                table: "ClienteMembresia",
                column: "IDCategoraMembresia");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteMembresia_IDCliente",
                table: "ClienteMembresia",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_IDPuesto",
                table: "Empleados",
                column: "IDPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaCliente_IDClienteMembresia",
                table: "FacturaCliente",
                column: "IDClienteMembresia");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPedidos_ID_DetalleFactura",
                table: "FacturaPedidos",
                column: "ID_DetalleFactura");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaPedidos_IDEmpleado",
                table: "FacturaPedidos",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_GeneracionPagos_IDJornadas",
                table: "GeneracionPagos",
                column: "IDJornadas");

            migrationBuilder.CreateIndex(
                name: "IX_HistortialPagos_IDGeneracionPagos",
                table: "HistortialPagos",
                column: "IDGeneracionPagos");

            migrationBuilder.CreateIndex(
                name: "IX_Jornadas_IDEmpleado",
                table: "Jornadas",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Martricula_IDCliente",
                table: "Martricula",
                column: "IDCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IDEmpleado",
                table: "Pedidos",
                column: "IDEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_IDProvedores",
                table: "Pedidos",
                column: "IDProvedores");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVenta_IDCategoriaProducto",
                table: "ProductosVenta",
                column: "IDCategoriaProducto");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosVenta_IDProvedores",
                table: "ProductosVenta",
                column: "IDProvedores");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesUV_IDClienteMembresia",
                table: "SesionesUV",
                column: "IDClienteMembresia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "FacturaCliente");

            migrationBuilder.DropTable(
                name: "FacturaPedidos");

            migrationBuilder.DropTable(
                name: "HistortialPagos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ProductosVenta");

            migrationBuilder.DropTable(
                name: "SesionesUV");

            migrationBuilder.DropTable(
                name: "Actividades");

            migrationBuilder.DropTable(
                name: "Martricula");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "DetalleFactura");

            migrationBuilder.DropTable(
                name: "GeneracionPagos");

            migrationBuilder.DropTable(
                name: "CategoriaProducto");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "ClienteMembresia");

            migrationBuilder.DropTable(
                name: "Jornadas");

            migrationBuilder.DropTable(
                name: "CategoriaMembresia");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Puesto");
        }
    }
}
