$(document).ready(

                function () {
                    $(".grid-result td:nth-child(7),.grid-result th:nth-child(7)").hide();
                    $(".grid-result td:nth-child(8),.grid-result th:nth-child(8)").hide();
                    $(".grid-result td:nth-child(9),.grid-result th:nth-child(9)").hide();
                    $(".grid-result th:nth-child(2)").text("Nombre producto");
                    $(".grid-result th:nth-child(3)").text("Categoria");
                    $(".grid-result th:nth-child(4)").text("Existencias");
                    $(".grid-result th:nth-child(5)").text("Precio unidad");
                    $(".grid-result th:nth-child(6)").text("Precio mayorista");
                }

);