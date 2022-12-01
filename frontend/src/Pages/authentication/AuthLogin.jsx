import React from 'react';
// import Card from '@mui/material/Card';
// import CardContent from '@mui/material/CardContent';
// import CardActionArea from '@mui/material/CardActionArea';
import Typography from '@mui/material/Typography';
import Button from '@mui/material/Button';
import Container from '@mui/material/Container';
import CssBaseline from '@mui/material/CssBaseline';
import Box from '@mui/material/Box';
// import Avatar from '@mui/material/Avatar';
// import { LoginOutlined } from '@ant-design/icons';
import TextField from '@mui/material/TextField';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { useTheme } from '@mui/material/styles';

import logger from '../../Common/logger';

function Copyright(props) {
  return (
    <Typography variant="caption" color="text.secondary" align="center" {...props}>
      {global.COPYRIGHT}
    </Typography>
  );
}

function AuthLogin() {
  const theme = useTheme();
  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    logger.log({
      email: data.get('email'),
      password: data.get('password'),
    });
  };
  return (
    <div className="login-card" style={{ background: theme.palette.background.default }}>
      <Container
        component="main"
        maxWidth="xs"
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
        }}
      >
        <CssBaseline />
        <Box
          sx={{
            marginTop: 1,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Typography component="h3" variant="h5">
            Motostore
          </Typography>
          <Box component="form" onSubmit={handleSubmit} noValidate sx={{ mt: 1 }}>
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email"
              name="email"
              // autoComplete="email"
              size="small"
              autoFocus
            />
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label="Password"
              type="password"
              id="password"
              size="small"
              autoComplete="current-password"
            />
            <FormControlLabel
              control={<Checkbox value="remember" color="primary" />}
              label={<Typography variant="body1">Rimani connesso</Typography>}
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 2, mb: 2 }}
            >
              Connetti
            </Button>
          </Box>
        </Box>
        <Copyright sx={{ mt: 1, mb: 1, fontSize: '0.7rem' }} />
      </Container>
    </div>
  );
}

export default AuthLogin;
