﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteCodenation.Application.ViewModel
{
    public class PratoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<PratosIngredientesViewModel> PratosIngredientes { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public int IdTipoPrato { get; set; }
        public TipoPratoViewModel TipoPrato { get; set; }
    }
}
