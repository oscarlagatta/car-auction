import type { Metadata } from "next";

import "./globals.css";
import {ReactNode} from "react";
import Navbar from "@/app/nav/Nav";


export const metadata: Metadata = {
  title: "Carsties",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Navbar />
        <main className="container mx-auto px-5 pt-10">
            {children}
        </main>

      </body>
    </html>
  );
}
