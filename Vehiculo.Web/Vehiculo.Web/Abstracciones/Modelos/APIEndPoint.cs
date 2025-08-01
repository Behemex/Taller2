﻿namespace Abstracciones.Modelos
{
    public class APIEndPoint
    {
        public string? UrlBase { get; set; }
        public IEnumerable<Metodo>? Metodos { get; set; }
    }
    public class Metodo
    {
        public string? Nombre { get; set; }
        public string? Valor { get; set; }
    }
}
