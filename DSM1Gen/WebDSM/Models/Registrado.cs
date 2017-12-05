﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebDSM.Models
{
    public class Registrado
    {

        [ScaffoldColumn(false)]
        public int id { get; set; }

        [ScaffoldColumn(false)]
        public bool admin { get; set; }

        //[ScaffoldColumn(false)]
        //public Valoracion valoracion { get; set;} //LISTA DE VALORACIONES DEL USUARIO

        //[ScaffoldColumn(false)]
        //public Pedido pedido { get; set; } //LISTA DE PEDIDOS DEL USUARIO

        //NO SE SI ES ASI
        //[ScaffoldColumn(false)]
        //public Carrito carrito { get; set; }

        //[ScaffoldColumn(false)]
        //public Puja pujaGanadora { get; set; }

        //[ScaffoldColumn(false)]
        //public IList<Articulo> favoritos { get; set; }

        //[ScaffoldColumn(false)]
        //public OfertaPuja ofertaPuja { get; set; }



        [Display(Prompt = "Nombre del usuario", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Debe de indicar un nombre para el usuario")]
        [StringLength(maximumLength: 50, MinimumLength = 0, ErrorMessage = "El nombre tiene que tener entre 0 y 50 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Apellidos del usuario", Description = "Apellidos del usuario", Name = "Apellidos")]
        [Required(ErrorMessage = "Debe de indicar unos apellidos para el usuario")]
        [StringLength(maximumLength: 70, MinimumLength = 0, ErrorMessage = "Los apellidos tiene que tener entre 0 y 70 caracteres")]
        public string apellidos { get; set; }

        [Display(Prompt = "Edad del usuario", Description = "Edad del usuario", Name = "Edad")]
        [Required(ErrorMessage = "Debe de introducir la edad del usuario")]
        [DataType(DataType.Currency, ErrorMessage = "La edad debe de ser un valor numérico")]
        [Range(minimum: 0, maximum: 100, ErrorMessage = "La edad debe de ser mayor que 0 y menor que 100")]
        public int edad { get; set; }

        [Display(Prompt = "Fecha de nacimiento del usuario", Description = "Fecha de nacimiento del usuario", Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "Debe de introducir la fecha de nacimiento del usuario")]
        [DataType(DataType.Currency, ErrorMessage = "La fecha de nacimiento debe de ser un valor de fecha")]
        //[Range(minimum: (int)new DateTime(1900,1,1), maximum: new DateTime(2000, 1, 1), ErrorMessage = "Debes de ser mayor de edad")]
        public DateTime? fNacimiento { get; set; }

        [Display(Prompt = "Contraseña del usuario", Description = "Contraseña del usuario", Name = "Contraseña")]
        [Required(ErrorMessage = "Debe de indicar una contraseña para el usuario")]
        [DataType(DataType.Password, ErrorMessage = "La contraseña debe de ser un valor de contraseña")]
        [StringLength(maximumLength: 70, MinimumLength = 0, ErrorMessage = "La contraseña tiene que tener entre 0 y 70 caracteres")]
        public string contrasenya { get; set; }

        [Display(Prompt = "Nombre de usuario", Description = "Nombre de usuario", Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Debe de indicar un nombre de usuario")]
        [StringLength(maximumLength: 30, MinimumLength = 0, ErrorMessage = "El nombre de usuario debe tener entre 0 y 30 caracteres")]
        public string nUsuario { get; set; }
        
        




    }
}