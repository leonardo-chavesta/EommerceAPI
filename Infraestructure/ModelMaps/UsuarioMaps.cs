using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.ModelMaps
{
    public class UsuarioMaps : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.Property(x => x.Nombre).HasColumnName("NOMBRE");
            builder.Property(x => x.Correo).HasColumnName("CORREO");
            builder.Property(x => x.Contrasenia).HasColumnName("CONTRASEÑA");
            builder.Property(x => x.Direccion).HasColumnName("DIRRECCION");
            builder.Property(x => x.Telefono).HasColumnName("TELEFONO");
            builder.Property(x => x.Token).HasColumnName("TOKEN");
            builder.Property(x => x.FechaNacimiento).HasColumnName("FECHA_NACIMIENTO");
            builder.Property(x => x.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            builder.Property(x => x.IdRoles).HasColumnName("ID_ROLES");
        }
    }
}
