import React from 'react';
import Box from '@mui/material/Box';
import { useTheme } from '@mui/material/styles';

import AuthBackground from './authentication/AuthBackground';

function LoginPage() {
  const theme = useTheme();
  return (
    <Box sx={{ minHeight: '100vh', background: theme.palette.background.default }}>
      <AuthBackground />
      <div>LoginPage</div>
    </Box>
  );
}

export default LoginPage;
