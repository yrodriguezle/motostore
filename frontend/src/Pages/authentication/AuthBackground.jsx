import React from 'react';
import Box from '@mui/material/Box';

import MotoInLoginSvg from './MotoSvg';

const AuthBackground = () => (
  <Box sx={{
    position: 'absolute',
    // zIndex: -1,
    bottom: 0,
    height: '50vh',
    background: 'var(--neutralLighterAlt)',
  }}
  >
    <MotoInLoginSvg
      width="100%"
      height="100%"
      backgroundColor="var(--neutralLighterAlt)"
    />
  </Box>
);

export default AuthBackground;
