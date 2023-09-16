namespace Proyecto_Vehiculo.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly int LengthPatente = 6;
         public bool IsColorValid(string MayuscColor)
            {
                var colorValid = MayuscColor[0].ToString().ToUpper() + MayuscColor.Substring(1);
                if (colorValid == MayuscColor)
                {
                    return true;
                }
                else
                {
                    return false;
                }
          }

            
        public bool IsPatenteValid(string patente)
        {

            var validPatente = patente.Length == LengthPatente;
            if (validPatente)  
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        
    }
}
