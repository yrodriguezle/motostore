import React, { Component } from 'react';
// import {
//   MessageBar, MessageBarType, Dialog, ProgressIndicator,
// } from 'office-ui-fabric-react';
import { withRouter } from 'react-router-dom';

const intervalIncrement = 0.01;
const intervalDelay = 100;

class ModuleErrorBoundary extends Component {
  constructor(props) {
    super(props);
    this.state = {
      hasError: false,
      // percentComplete: 0,
    };
    this.decrementProgress = this.decrementProgress.bind(this);
  }

  static getDerivedStateFromError() {
    return { hasError: true };
  }

  componentDidUpdate(prevProps, prevState) {
    const { hasError } = this.state;
    if (prevState.hasError !== hasError) {
      this.decrementProgress();
    }
  }

  decrementProgress() {
    const intervalId = setInterval(
      (instance) => {
        if (instance.state.percentComplete < 0.9) {
          instance.setState({
            percentComplete: (intervalIncrement + instance.state.percentComplete) % 1,
          });
        } else {
          clearInterval(intervalId);
          this.props.history.push('/');
        }
      },
      intervalDelay,
      this,
    );
  }

  render() {
    if (this.state.hasError) {
      return (
        <div>ERROR</div>
        // <Dialog hidden={false}>
        //   <MessageBar messageBarType={MessageBarType.error}>
        //     Pagina non trovata, contatta il supporto tecnico per segnalare il problema.
        //   </MessageBar>
        //   <ProgressIndicator
        //     label="Attendi per favore..."
        //     percentComplete={this.state.percentComplete}
        //   />
        // </Dialog>
      );
    }

    return this.props.children;
  }
}

export default withRouter(ModuleErrorBoundary);
