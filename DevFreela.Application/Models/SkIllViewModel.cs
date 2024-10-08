﻿using DevFreela.Core.Entities;

namespace DevFreela.Application.Models
{
    public class SkIllViewModel
    {
        public SkIllViewModel(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public int Id { get; set; }

        public string Descricao { get; set; }

        public static SkIllViewModel FromEntity(Skill skill)
            => new(skill.Id, skill.Description);
    }
}
