using System.Collections.Generic;

namespace LiteApiApiKeySecretSample.Services
{
    public interface IApiKeySecretStore
    {
        bool ValidateKeySecret(string key, string secret);
    }

    /// <summary>
    /// Dummy implementation of key secret store. Should be implemented using DB or 
    /// some other form of permanent storage.
    /// </summary>
    public class DummyApiKeySecretStore : IApiKeySecretStore
    {
        private Dictionary<string, string> _keySecretPairs = new Dictionary<string, string>();

        public DummyApiKeySecretStore()
        {
            _keySecretPairs["key1"] = "secret1";
            _keySecretPairs["key2"] = "secret2";
            _keySecretPairs["key3"] = "secret3";
            _keySecretPairs["key4"] = "secret4";
        }

        public bool ValidateKeySecret(string key, string secret)
            => _keySecretPairs.ContainsKey(key) && _keySecretPairs[key] == secret;
    }
}
