import { useEffect } from 'react';
import logger from '../../../Common/logger';

function useFocusToFieldError() {
  useEffect(() => {
    logger.log('here');
  }, []);
}

export default useFocusToFieldError;
