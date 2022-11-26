import {
  Button, Dialog, DialogActions, DialogBody, DialogContent, DialogSurface, DialogTitle,
} from '@fluentui/react-components';
import React, { useCallback } from 'react';
import { useNavigate } from 'react-router-dom';
import appMessages from '../../../Messages/appMessages';

function ViewAccessDenied() {
  const navigate = useNavigate();
  const handleAccept = useCallback(
    () => {
      navigate(-1);
    },
    [navigate],
  );

  return (
    <Dialog open>
      <DialogSurface>
        <DialogBody>
          <DialogTitle>{appMessages.accessDeniedDialog.title}</DialogTitle>
          <DialogContent>
            {appMessages.accessDeniedDialog.body}
          </DialogContent>
          <DialogActions>
            <Button autoFocus appearance="primary" onClick={handleAccept}>{appMessages.accessDeniedDialog.accept}</Button>
          </DialogActions>
        </DialogBody>
      </DialogSurface>
    </Dialog>
  );
}

export default ViewAccessDenied;
