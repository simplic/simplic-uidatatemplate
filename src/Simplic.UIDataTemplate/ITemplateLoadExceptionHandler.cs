using System;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Handler for handling exceptions
    /// </summary>
    public interface ITemplateLoadExceptionHandler
    {
        /// <summary>
        /// Handle an exception
        /// </summary>
        /// <param name="ex">Exception instance</param>
        /// <returns>True if the exception was handled</returns>
        bool Handle(Exception ex);
    }
}