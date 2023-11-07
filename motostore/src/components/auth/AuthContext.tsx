import { createContext } from "react";
import { User } from "../../types.d";

interface AuthContextType {
  user: User | null
  signin: (username: string, callback: VoidFunction) => void
  signout: (callback: VoidFunction) => void
}

const AuthContext = createContext<AuthContextType>(null!);

export default AuthContext;
