﻿using CleanArchitecture.Domain.BuildingBlocks.Interfaces;
using CleanArchitecture.SharedKernels.Exceptions;

namespace CleanArchitecture.Domain.BuildingBlocks.BaseTypes
{
    public abstract class Entity<Key> : IEntity<Key>
    {
        /// <summary>
        /// 
        /// </summary>
        public Entity()
        {

        }

        /// <summary>
        /// Entity Identifier
        /// </summary>
        public Key Id { get; protected set; }

        /// <summary>
        /// Validate on business rule
        /// </summary>
        /// <param name="rule"></param>
        /// <exception cref="BusinessException"></exception>
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
                throw new BusinessRuleException(rule.Message);
        }
    }
}
