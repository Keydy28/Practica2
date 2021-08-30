using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica_II.Pages
{
    public class NominaModel : PageModel
    {

        public List<Empleado> ListaEmpleado = new List<Empleado>();
        public void OnGet()
        {
            this.ListaEmpleado.Add(
                new Empleado()
                {
                    Nombres = "Keydy",
                    Apellidos = "Matos",
                    Cargo = "Gerente",
                    SalarioMensual = 125000,
                    DescuentoAFP = RetencionAFP(125000),
                    DescuentoARS = RetencionARS(125000),
                    DescuentoISR = RetencionISR(125000),
                    TotalDescuento = Descuento(125000),
                    SalarioNeto = 125000 - Descuento(125000)
                }
            );

            this.ListaEmpleado.Add(new Empleado()
            {
                Nombres = "Juan Luis",
                Apellidos = "Abreu",
                Cargo = "Director TIC",
                SalarioMensual = 175000,
                DescuentoAFP = RetencionAFP(175000),
                DescuentoARS = RetencionARS(175000),
                DescuentoISR = RetencionISR(175000),
                TotalDescuento = Descuento(175000),
                SalarioNeto = 175000 - Descuento(175000)

            });

            this.ListaEmpleado.Add(new Empleado()
            {
                Nombres = "Hector",
                Apellidos = "Montero",
                Cargo = "Sub-Gerente",
                SalarioMensual = 95000,
                DescuentoAFP = RetencionAFP(95000),
                DescuentoARS = RetencionARS(95000),
                DescuentoISR = RetencionISR(95000),
                TotalDescuento = Descuento(95000),
                SalarioNeto = 95000 - Descuento(95000)
            });

                                        
        }
        double RetencionAFP(double SalarioMensual)
        {
            double RetencionAFP = (SalarioMensual * 2.87) / 100;
            if (RetencionAFP > 4098.53)
            {
                RetencionAFP = 4098.53;
            }
            return RetencionAFP;
        }
        double RetencionARS(double SalarioMensual)
        {
            double RetencionARS = (SalarioMensual * 3.04 / 100);
            if (RetencionARS > 7738.67)
            {
                RetencionARS = 7738.67;
            }
                        
                return RetencionARS;
            }
                                              
        double RetencionISR(double SalarioMensual)
        {
            double SalarioIRS = SalarioMensual - (RetencionAFP(SalarioMensual) + RetencionARS(SalarioMensual));
            double SalarioAnual = SalarioIRS * 12;
            double RetencionISR = 0;



            if (SalarioAnual > 867123.01)
            {
                 RetencionISR = (((SalarioAnual - 867123.01)/12) * 25 / 100) + (79776 / 12);
                 
            }
            else if (SalarioAnual>624329.01)
            {
                 RetencionISR = (((SalarioAnual-624329.01) /12)*20 / 100) + (31216 / 12);
                 
            }
            else  if (SalarioAnual>416220.01)
            {
                RetencionISR = ((SalarioAnual - 416220.01) / 12) *( 15 / 100);
                
            }

            return RetencionISR;          
                                     
        }
        double Descuento(double TotalDescuento)
        {
            double TotalDescueto = RetencionARS(TotalDescuento)+ RetencionAFP(TotalDescuento)+RetencionISR(TotalDescuento);
            return TotalDescueto;
                        
        }
            
            
                 
    } 
    public class Empleado
    {
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cargo { get; set; }
        public double SalarioMensual { get; set; }
        public double DescuentoAFP { get; set; }
        public double DescuentoARS { get; set; }
        public double DescuentoISR { get; set; }
        public double TotalDescuento { get; set; }
        public double SalarioNeto { get; set; }
    }
}
