using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleCqrs.Core.Tests
{
    public static class CustomAsserts
    {
        [DebuggerStepThrough()]
        public static T Throws<T>(Action action) where T : Exception
        {
            try
            {
                action.Invoke();
            }
            catch (T ex)
            {
                return ex;
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(
                    string.Format("Expected exception was not thrown! Got other exception: '{0}'.", ex.GetType())
                    ,ex);
            }

            throw new AssertFailedException("Expected exception was not thrown! None was thrown.");
        }

        [DebuggerStepThrough()]
        public static async Task<T> ThrowsAsync<T>(Task action) where T : Exception
        {
            try
            {
                await action.ConfigureAwait(false);
            }
            catch (T ex)
            {
                return ex;
            }
            catch (AggregateException ex)
            {
            }
            catch (Exception ex)
            {
                throw new AssertFailedException(
                    string.Format("Expected exception was not thrown! Got other exception: '{0}'.", ex.GetType())
                    ,ex);
            }

            throw new AssertFailedException("Expected exception was not thrown! None was thrown.");
        }
    }
}