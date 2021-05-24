using System;
using System.Collections.Generic;
using System.Text;

namespace EstoqueBrilhador.Dominio._Base
{
    public interface IModel { }
    public class Entidade<TEntity, TId> : IModel
        where TId: struct
        where TEntity: Entidade<TEntity, TId>
    {
        public TId Id { get; set; }

        public override bool Equals(object obj)
        {
            TEntity comparedEntity = obj as TEntity;

            if(ReferenceEquals(this, comparedEntity))
            {
                return true;
            }

            if(comparedEntity is null)
            {
                return false;
            }

            return Id.Equals(comparedEntity.Id);
        }

        public static bool operator ==(Entidade<TEntity, TId> a, Entidade<TEntity, TId> b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entidade<TEntity, TId> a, Entidade<TEntity, TId> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id=" + Id + "]";
        }
    }
}
