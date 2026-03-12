import type { ReactNode } from "react";

type Props = {
  children: ReactNode;
};

function Layout({ children }: Props) {
  return (
    <div className="min-h-screen bg-gray-200">
      <div className="max-w-6xl mx-auto px-6 py-8">
        {children}
      </div>
    </div>
  );
}

export default Layout;