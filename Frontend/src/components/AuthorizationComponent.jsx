import React, { useEffect } from 'react';

const AuthorizationComponent = () => {
  useEffect(() => {
    // Redirect the user to Freshbooks authorization page
    window.location.href = 'https://localhost:44357/api/Auth/redirect';
  }, []);

  return (
    <div>
      <p>Redirecting to Freshbooks for authorization...</p>
    </div>
  );
};

export default AuthorizationComponent;