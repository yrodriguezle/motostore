import React, {
  forwardRef, useCallback, useEffect, useImperativeHandle, useRef, useState,
} from 'react';
import MUITextField from '@mui/material/TextField';
import InputAdornment from '@mui/material/InputAdornment';
import IconButton from '@mui/material/IconButton';
import { EyeOutlined, EyeInvisibleOutlined } from '@ant-design/icons';

const handleMouseDownPassword = (event) => {
  event.preventDefault();
};

function TextField({
  value,
  name,
  textUpperCase,
  onChange,
  ...props
}, ref) {
  const inputRef = useRef(null);
  const caretSelection = useRef();
  const [innerValue, setInnerValue] = useState(value);
  const [showPassword, setSowPassword] = useState(false);

  const handleClickShowPassword = useCallback(
    () => setSowPassword((prev) => !prev),
    [],
  );

  useEffect(() => () => {
    caretSelection.current = null;
  }, []);

  // useEffect(() => {
  //   if (inputRef.current && caretSelection.current) {
  //     const { selectionStart, selectionEnd } = inputRef.current;
  //     const update = (caretSelection.current.start !== false && caretSelection.current?.start !== selectionStart)
  //       || (caretSelection.current.end !== false && caretSelection.current.end !== selectionEnd);
  //     if (update) {
  //       inputRef.current.setSelectionStart(caretSelection.current.start);
  //       inputRef.current.setSelectionEnd(caretSelection.current.end);
  //     }
  //   }
  // }, [innerValue]);

  useEffect(() => {
    setInnerValue(value);
  }, [value]);

  const handleChange = useCallback(
    (event) => {
      let transformedValue = event.target.value;
      if (textUpperCase) {
        transformedValue = transformedValue.toUpperCase();
      }
      if (onChange && typeof onChange === 'function') {
        onChange(name, transformedValue);
      } else {
        setInnerValue(transformedValue);
      }
      caretSelection.current = {
        start: event.target.selectionStart,
        end: event.target.selectionEnd,
      };
    },
    [name, onChange, textUpperCase],
  );

  useImperativeHandle(
    ref,
    () => ({
      focus: () => {
        inputRef.current.focus();
      },
      isCancelBeforeStart: () => {
        setTimeout(() => {
          if (inputRef.current) {
            inputRef.current.focus();
          }
        }, 0);
      },
      getValue: () => innerValue,
    }),
    [innerValue],
  );

  return (
    <MUITextField
      ref={inputRef}
      size="small"
      value={innerValue}
      onChange={handleChange}
      InputProps={{
        endAdornment: props.type === 'password' ? (
          <InputAdornment position="end">
            <IconButton
              aria-label="toggle password visibility"
              onClick={handleClickShowPassword}
              onMouseDown={handleMouseDownPassword}
            >
              {showPassword ? <EyeInvisibleOutlined /> : <EyeOutlined />}
            </IconButton>
          </InputAdornment>
        ) : undefined,
      }}
      {...props}
      type={showPassword ? 'text' : 'password'}
    />
  );
}

export default forwardRef(TextField);
