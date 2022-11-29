import React from 'react';
import { useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';

import MotoInLoginSvg from './MotoSvg';

const AuthBackground = () => {
  const theme = useTheme();
  return (
    <Box sx={{
      position: 'absolute',
      // zIndex: -1,
      bottom: 0,
      height: '50vh',
      background: theme.palette.background.default,
    }}
    >
      <MotoInLoginSvg
        width="100%"
        height="100%"
        backgroundColor={theme.palette.background.default}
      />
    </Box>
  );
};

export default AuthBackground;
