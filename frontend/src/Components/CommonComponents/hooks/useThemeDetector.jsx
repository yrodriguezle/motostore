import { useCallback, useEffect } from 'react';

import logger from '../../../Common/logger';

function useThemeDetector() {
  // const isThemeDark = useSelector((state) => state.settings?.darkTheme);

  useEffect(() => {
    const isSystemDarkTheme = window.matchMedia('(prefers-color-scheme: dark)').matches;
    logger.log('isSystemDarkTheme', isSystemDarkTheme);
  }, []);

  const handleChangeSystemTheme = useCallback(
    (event) => {
      const darker = event.matches;
      logger.log('darker', darker);
    },
    [],
  );

  useEffect(() => {
    const mediaQueryList = window.matchMedia('(prefers-color-scheme: dark)');
    mediaQueryList.addEventListener('change', handleChangeSystemTheme);
    return () => mediaQueryList.removeEventListener('change', handleChangeSystemTheme);
  }, [handleChangeSystemTheme]);

  // useEffect(() => {
  //   if (isThemeDark) {
  //     document.documentElement.setAttribute('data-theme', 'dark');
  //   } else {
  //     document.documentElement.setAttribute('data-theme', 'light');
  //   }
  // }, [isThemeDark]);
}

export default useThemeDetector;
