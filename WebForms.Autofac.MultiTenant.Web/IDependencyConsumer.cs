using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebForms.Autofac.MultiTenant.Minimal
{
    /// <summary>
    /// Demonstration interface for a consumer of a dependency. Enables the ability
    /// to illustrate resolving components across global and tenant-specific scopes.
    /// </summary>
    public interface IDependencyConsumer
    {
        /// <summary>
        /// Gets the dependency for this consumer.
        /// </summary>
        /// <value>
        /// An <see cref="MultitenantExample.ConsoleApplication.IDependency"/>
        /// held by this specific consumer.
        /// </value>
        IDependency Dependency { get; }
    }
}
