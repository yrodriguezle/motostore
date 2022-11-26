import React, { Component } from 'react';
import {
  Dialog, DialogBody, DialogContent, DialogSurface, DialogTitle,
} from '@fluentui/react-components';
import appMessages from '../../../Messages/appMessages';

class ModuleErrorBoundary extends Component {
  constructor() {
    super();
    this.state = {
      hasError: false,
    };
  }

  static getDerivedStateFromError() {
    return { hasError: true };
  }

  render() {
    if (this.state.hasError) {
      return (
        <Dialog open>
          <DialogSurface>
            <DialogBody>
              <DialogTitle>Errore</DialogTitle>
              <DialogContent>
                {appMessages.routesError.body}
              </DialogContent>
            </DialogBody>
          </DialogSurface>
        </Dialog>
      );
    }

    return this.props.children;
  }
}

export default ModuleErrorBoundary;
